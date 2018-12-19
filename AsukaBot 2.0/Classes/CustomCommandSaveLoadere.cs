using AsukaBot_2._0.Module.CustomCommand;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AsukaBot_2._0.Classes
{
    class CustomCommandSaveLoadere
    {
        private string FilePath = Directory.GetCurrentDirectory() + @"\assets\CCList.xml";
        private XmlTextWriter Writer;
        private XmlTextReader Reader;


        public List<CustomCommandBase> LoadCCFromFile()
        {
            CCType CurrentNodeMode;
            List<CustomCommandBase> CommandsList = new List<CustomCommandBase>();
            if(CheckIfFileExist())
            {
                Reader = new XmlTextReader(FilePath);
                while (Reader.Read())
                {
                    switch(Reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            switch(Reader.Name)
                            {

                            }
                            break;

                        case XmlNodeType.EndElement:
                            
                            break;
                    }
                }
                Reader.Close();
            }
            return CommandsList;
        }

        public void SaveCCToFile(List<CustomCommandBase> CCToSave)
        {
            //should probably return some kind of data that tells the user if the file has not been saved correctly 
            if(CheckIfFileExist())
            {
                Writer = new XmlTextWriter(FilePath, Encoding.UTF8);
                Writer.WriteStartDocument(true);
                Writer.Formatting = Formatting.Indented;
                Writer.Indentation = 2;
                Writer.WriteStartElement("CustomCommands");
                if (CCToSave != null || CCToSave.Count != 0)
                {
                    foreach (CustomCommandBase element in CCToSave)
                    {
                        switch (element.myCCType)
                        {
                            case CCType.Text:
                                CustomCommandText Element = element as CustomCommandText;
                                Writer.WriteStartElement("Command");
                                Writer.WriteAttributeString("CommandType", Element.myCCType.ToString());
                                Writer.WriteStartElement("CommandWord");
                                Writer.WriteStartAttribute("Value", Element.CommandName);
                                Writer.WriteEndElement();
                                Writer.WriteStartElement("Creator");
                                Writer.WriteStartAttribute("Value", Element.Creator);
                                Writer.WriteEndElement();
                                Writer.WriteStartElement("ReturnText");
                                Writer.WriteAttributeString("Text", Element.TextReturnCommand);
                                Writer.WriteEndElement();
                                Writer.WriteEndElement();
                                break;

                            case CCType.UserChange:

                                break;
                        }
                    }
                }
                Writer.WriteEndElement();
                Writer.WriteEndDocument();
                Writer.Close();
                Writer = null;
            }
        }

        private bool CheckIfFileExist()
        {
            if(Directory.Exists(Directory.GetCurrentDirectory() +@"\assets"))
            {
                if(File.Exists(FilePath))
                {
                    return true;
                }
                else
                {
                    File.Create(FilePath);
                    return false;
                }
            }
            else
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\assets");
                File.Create(FilePath);
                return false;
            }
        }

    }
}
