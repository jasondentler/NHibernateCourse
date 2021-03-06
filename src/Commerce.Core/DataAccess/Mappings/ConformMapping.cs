﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Commerce.Core.Entities;
using ConfOrm;
using ConfOrm.NH;
using ConfOrm.Patterns;
using ConfOrm.Shop.CoolNaming;
using ConfOrm.Shop.InflectorNaming;
using ConfOrm.Shop.Inflectors;
using ConfOrm.Shop.Packs;
using NHibernate.Cfg.MappingSchema;

namespace Commerce.Core.DataAccess.Mappings
{
    class ConformMapping
    {

        public HbmMapping GenerateMappings()
        {
            var domainEntities = GetDomainEntities().ToArray();

            var relationalMapper = new ObjectRelationalMapper();
            relationalMapper.TablePerClassHierarchy(domainEntities); 
            relationalMapper.Patterns.PoidStrategies.Add(new HighLowPoidPattern());

            var patternsAppliers = new CoolPatternsAppliersHolder(relationalMapper); 
            patternsAppliers.Merge(new ClassPluralizedTableApplier(new EnglishInflector())); 
            patternsAppliers.Merge(new UseNoLazyForNoProxablePack());
            var mapper = new Mapper(relationalMapper, patternsAppliers);

            var mapping = mapper.CompileMappingFor(domainEntities);
            Debug.WriteLine(Serialize(mapping));

            return mapping;
        }

        private static IEnumerable<Type> GetDomainEntities()
        {
            Assembly domainAssembly = typeof (Customer).Assembly;
            IEnumerable<Type> domainEntities = from t in domainAssembly.GetTypes()
                                               where t.IsClass
                                               where !t.IsAbstract
                                               where typeof (IEntity).IsAssignableFrom(t)
                                               select t;
            return domainEntities;
        }

        /// <summary>
        /// Generates XML string from <see cref="NHibernate"/> mappings. Used just to verify what was generated by ConfOrm to make sure everything is correct.
        /// </summary>
        protected static string Serialize(HbmMapping hbmElement)
        {
            var setting = new XmlWriterSettings { Indent = true };
            var serializer = new XmlSerializer(typeof(HbmMapping));
            using (var memStream = new MemoryStream())
            {
                using (var xmlWriter = XmlWriter.Create(memStream, setting))
                {
                    serializer.Serialize(xmlWriter, hbmElement);
                    memStream.Flush();
                    byte[] streamContents = memStream.ToArray();

                    string result = Encoding.UTF8.GetString(streamContents);
                    return result;
                }
            }
        }
    }
}
