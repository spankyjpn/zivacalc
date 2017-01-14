using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace destinycalc01
{
    public class libCoreData
    {
        /// <summary>
        /// アプリケーションの保存データを削除する
        /// </summary>
        public void purge()
        {
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "localCoreData.xml";

            if (File.Exists(dataPath))
            {
                File.Delete(dataPath);
            }
        }

        /// <summary>
        /// アプリケーションデータを保存する
        /// </summary>
        /// <param name="data">保存するclsCoreDataの配列</param>
        public void save(ArrayList data)
        {
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "localCoreData.xml";

            DataSet ds = new DataSet("CoreDataSaveData");
            DataTable dt = ds.Tables.Add("CoreDataTable");

            dt.Columns.Add("title", typeof(string));
            dt.Columns.Add("type", typeof(string));
            dt.Columns.Add("data", typeof(string));
            dt.Columns.Add("sttval", typeof(int));
            dt.Columns.Add("endval", typeof(int));
            dt.Columns.Add("coredt", typeof(string));

            foreach (clsCoreData cell in data)
            {
                DataRow dr = dt.NewRow();

                StringBuilder sb = new StringBuilder();
                foreach (int tmp in cell.coreData)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append(String.Format("{0,5}", tmp));
                }

                dr["title"] = cell.title;
                dr["type"] = cell.dataType.ToString();
                dr["sttval"] = cell.sttValue;
                dr["endval"] = cell.endValue;
                dr["data"] = sb.ToString();

                dt.Rows.Add(dr);
            }

            ds.WriteXml(dataPath, XmlWriteMode.WriteSchema);
        }

        /// <summary>
        /// アプリケーションデータを読み込む
        /// </summary>
        /// <returns>読み込んだclsCoreDataの配列</returns>
        public ArrayList load()
        {
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "localCoreData.xml";
            ArrayList ret = new ArrayList();

            if ( !File.Exists(dataPath) )
            {
                return ret;
            }

            DataSet ds = new DataSet();

            ds.ReadXml(dataPath);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                clsCoreData cd = new clsCoreData();

                cd.title = (string)dr["title"];
                cd.dataType = (clsCoreData.coreDataType)Enum.Parse(typeof(clsCoreData.coreDataType), (string)dr["type"]);
                cd.sttValue = (int)dr["sttval"];
                cd.endValue = (int)dr["endval"];

                string dat = (string)dr["data"];
                string[] tmp = dat.Split(',');
                int pos = 0;
                foreach (string sdat in tmp)
                {
                    cd.coreData[pos++] = int.Parse(sdat.Trim());
                }

                ret.Add(cd);
            }

            return ret;
        }
    }
}
