using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AyurvedicDictionary.Code {
    public class AyurvedicDictionaryProvider {
        public const string NiaMdbFilePath = @"~\App_Data\NIA_AyurvedicDictionary2015.mdb";

        public List<AyurvedicDictionaryTerm> Terms { get; set; }
        private static readonly object lockObject = new object();
        static AyurvedicDictionaryProvider cachedProvider;
        static AyurvedicDictionaryProvider CachedProvider {
            get {
                lock(lockObject) {
                    if(cachedProvider == null) {
                        cachedProvider = new AyurvedicDictionaryProvider();
                        cachedProvider.Terms = new List<AyurvedicDictionaryTerm>();

                        PopulateTerms(cachedProvider.Terms);
                    }
                    return cachedProvider;
                }
            }
        }

        public static List<AyurvedicDictionaryTerm> GetTerms() {
            return CachedProvider.Terms;
        }
        public static void RefreshTerms() {
            lock(lockObject) {
                if(cachedProvider != null)
                    cachedProvider.Terms.Clear();
                cachedProvider = null;
            }
        }

        static void PopulateTerms(List<AyurvedicDictionaryTerm> terms) {
            // In this sample, we use a local database (MS Access) for demo purposes, because 
            // it is easy to deploy. 
            // You can use the Entity Framework or other ORM (Object-Relational Mapping) technology 
            // to retrieve all items (Terms) from a data table.
            AccessDataSource ds = new AccessDataSource();
            ds.DataFile = NiaMdbFilePath;
            ds.SelectCommand = "SELECT * FROM [Terms] ORDER BY [DEVANAGARI]";
            IEnumerable data = ds.Select(new DataSourceSelectArguments());
            if(data is DataView) {
                DataView dataView = data as DataView;
                for(int i = 0; i < dataView.Count; i++) {
                    AyurvedicDictionaryTerm item = new AyurvedicDictionaryTerm();
                    item.Id = (int)dataView[i]["ID"];
                    item.Devanagari = (string)dataView[i]["DEVANAGARI"];
                    item.IAST = (string)dataView[i]["IAST"];
                    item.HarvardKyoto = (string)dataView[i]["HarvardKyoto"];
                    item.EnglishText = (string)dataView[i]["ENGLISH"];
                    terms.Add(item);
                }
            }
        }
    }

    public class AyurvedicDictionaryTerm {
        public int Id { get; set; }
        public string Devanagari { get; set; }
        public string IAST { get; set; }
        public string HarvardKyoto { get; set; }
        public string EnglishText { get; set; }
    }
}