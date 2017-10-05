using System;
using System.Windows.Forms;

namespace _3Cam_FiberAlignment
{
    //XMLファイルに保存するオブジェクトのためのクラス

    public class XmlSerializ
    {
        //AppConfClassオブジェクトをXMLファイルに保存する
        public static void Write(AppConfClass obj)
        {
            bool CheckClose = true;
            System.IO.StreamWriter sw = null;
            try
            {
                //保存先のファイル名
                //string fileName = System.Environment.CurrentDirectory + xmlname;
                string d = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string fileName = d.Substring(0, d.LastIndexOf(@"\")) + @"\" + Application.ProductName + ".xml";

                //XMLファイルに保存する
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(AppConfClass));
                sw = new System.IO.StreamWriter(
                    fileName, false, new System.Text.UTF8Encoding(false));
                serializer.Serialize(sw, obj);
            }
            catch (InvalidOperationException ex)
            {
                CheckClose = false;
                MessageBox.Show(ex.Message, "Get(AppConfClass)");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Set(AppConfClass)");
            }
            finally
            {
                if (CheckClose) sw.Close();
            }
        }

        //AppConfClassオブジェクトをXMLファイルに復元する
        public static void Read(out AppConfClass obj)
        {
            obj = new AppConfClass();   //初期化
                                        //読込先のファイル名
            string d = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string fileName = d.Substring(0, d.LastIndexOf(@"\")) + @"\" + Application.ProductName + ".xml";
            if (System.IO.File.Exists(fileName))
            {
                bool CheckClose = true;
                System.IO.StreamReader sr = null;
                try
                {
                    //保存した内容を復元する
                    System.Xml.Serialization.XmlSerializer serializer =
                        new System.Xml.Serialization.XmlSerializer(typeof(AppConfClass));
                    sr = new System.IO.StreamReader(
                        fileName, new System.Text.UTF8Encoding(false));
                    obj = (AppConfClass)serializer.Deserialize(sr);
                }
                catch (InvalidOperationException ex)
                {
                    CheckClose = false;
                    MessageBox.Show(ex.Message, "Get(AppConfClass)");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Get(AppConfClass)");
                }
                finally
                {
                    if (CheckClose) sr.Close();
                }
            }
            else
            {
#if DEBUG
                MessageBox.Show("Not File : " + fileName);
#endif
            }
        }


    }
}
