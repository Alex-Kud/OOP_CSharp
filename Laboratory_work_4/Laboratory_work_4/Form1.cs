using System;
using System.Reflection;
using System.Windows.Forms;

namespace Laboratory_work_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            Type libType = Type.GetType("Laboratory_work_4.Library", false, true);
            Type bookType = Type.GetType("Laboratory_work_4.Book", false, true);
            Type artType = Type.GetType("Laboratory_work_4.ArtBook", false, true);
            Type textbookType = Type.GetType("Laboratory_work_4.Textbook", false, true);
            TreeNode libNode = new TreeNode("Library");
            TreeNode bookNode = new TreeNode("Book");
            TreeNode artNode = new TreeNode("ArtBook");
            TreeNode textbookNode = new TreeNode("Textbook");
            TreeNode libMethods = new TreeNode("Методы");
            TreeNode bookMethods = new TreeNode("Методы");
            TreeNode artMethods = new TreeNode("Методы");
            TreeNode textbookMethods = new TreeNode("Методы");
            TreeNode libFields = new TreeNode("Поля");
            TreeNode bookFields = new TreeNode("Поля");
            TreeNode artFields = new TreeNode("Поля");
            TreeNode textbookFields = new TreeNode("Поля");
            TreeNode libProperties = new TreeNode("Свойства");
            TreeNode bookProperties = new TreeNode("Свойства");
            TreeNode artProperties = new TreeNode("Свойства");
            TreeNode textbookProperties = new TreeNode("Свойства");

            // Методы
            foreach (MethodInfo method in libType.GetMethods())
            {
                string met = "";
                string modificator = "";
                if (method.IsStatic)
                    modificator += "static ";
                if (method.IsVirtual)
                    modificator += "virtual";
                met += modificator + " " + method.ReturnType.Name + " " + method.Name + " (";
                //получаем все параметры
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    met += parameters[i].ParameterType.Name + " " + parameters[i].Name + ")";
                    if (i + 1 < parameters.Length) met += ", ";
                }
                met += ")";
                libMethods.Nodes.Add(new TreeNode(met));
            }
            foreach (MethodInfo method in bookType.GetMethods())
            {
                string met = "";
                string modificator = "";
                if (method.IsStatic)
                    modificator += "static ";
                if (method.IsVirtual)
                    modificator += "virtual";
                met += modificator + " " + method.ReturnType.Name + " " + method.Name + " (";
                //получаем все параметры
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    met += parameters[i].ParameterType.Name + " " + parameters[i].Name + ")";
                    if (i + 1 < parameters.Length) met += ", ";
                }
                met += ")";
                bookMethods.Nodes.Add(new TreeNode(met));
            }
            MethodInfo[] artMethod = artType.GetMethods(BindingFlags.DeclaredOnly); // без наследуемых
            for (int j = 0; j < artMethod.Length; j++) {
                string met = "";
                string modificator = "";
                if (artMethod[j].IsStatic)
                    modificator += "static ";
                if (artMethod[j].IsVirtual)
                    modificator += "virtual";
                met += modificator + " " + artMethod[j].ReturnType.Name + " " + artMethod[j].Name + " (";
                //получаем все параметры
                ParameterInfo[] parameters = artMethod[j].GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    met += parameters[i].ParameterType.Name + " " + parameters[i].Name + ")";
                    if (i + 1 < parameters.Length) met += ", ";
                }
                met += ")";
                artMethods.Nodes.Add(new TreeNode(met));
            }
            MethodInfo[] textbookMethod = artType.GetMethods(BindingFlags.DeclaredOnly); // без наследуемых
            for (int j = 0; j < textbookMethod.Length; j++)
            {
                string met = "";
                string modificator = "";
                if (textbookMethod[j].IsStatic)
                    modificator += "static ";
                if (textbookMethod[j].IsVirtual)
                    modificator += "virtual";
                met += modificator + " " + textbookMethod[j].ReturnType.Name + " " + textbookMethod[j].Name + " (";
                //получаем все параметры
                ParameterInfo[] parameters = textbookMethod[j].GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    met += parameters[i].ParameterType.Name + " " + parameters[i].Name + ")";
                    if (i + 1 < parameters.Length) met += ", ";
                }
                met += ")";
                textbookMethods.Nodes.Add(new TreeNode(met));
            }
            // Поля
            foreach (FieldInfo field in libType.GetFields())
                libFields.Nodes.Add(new TreeNode(field.FieldType + " " + field.Name));
            foreach (FieldInfo field in bookType.GetFields())
                bookFields.Nodes.Add(new TreeNode(field.FieldType + " " + field.Name));
            foreach (FieldInfo field in artType.GetFields())
                artFields.Nodes.Add(new TreeNode(field.FieldType + " " + field.Name));
            foreach (FieldInfo field in textbookType.GetFields())
                textbookFields.Nodes.Add(new TreeNode(field.FieldType + " " + field.Name));
            // Свойства
            foreach (PropertyInfo prop in libType.GetProperties())
                libProperties.Nodes.Add(new TreeNode(prop.PropertyType + " " + prop.Name));
            foreach (PropertyInfo prop in bookType.GetProperties())
                bookProperties.Nodes.Add(new TreeNode(prop.PropertyType + " " + prop.Name));
            foreach (PropertyInfo prop in artType.GetProperties())
                artProperties.Nodes.Add(new TreeNode(prop.PropertyType + " " + prop.Name));
            foreach (PropertyInfo prop in textbookType.GetProperties())
                textbookProperties.Nodes.Add(new TreeNode(prop.PropertyType + " " + prop.Name));
            // Формирование в TreeView
            // Добавляем новые дочерние узелы к tlibNode
            libNode.Nodes.Add(libMethods);
            libNode.Nodes.Add(libFields);
            libNode.Nodes.Add(libProperties);
            // Добавляем новые дочерние узелы к bookNode
            bookNode.Nodes.Add(bookMethods);
            bookNode.Nodes.Add(bookFields);
            bookNode.Nodes.Add(bookProperties);
            // Добавляем новые дочерние узелы к artNode
            artNode.Nodes.Add(artMethods);
            artNode.Nodes.Add(artFields);
            artNode.Nodes.Add(artProperties);
            // Добавляем новые дочерние узелы к textbookNode
            textbookNode.Nodes.Add(textbookMethods);
            textbookNode.Nodes.Add(textbookFields);
            textbookNode.Nodes.Add(textbookProperties);
            // Добавление узлов в TreeView
            treeView1.Nodes.Add(libNode);
            treeView1.Nodes.Add(bookNode);
            treeView1.Nodes.Add(artNode);
            treeView1.Nodes.Add(textbookNode);
            // раскрытие не только узла, но и всех его дочерних подузлов
            libNode.ExpandAll();
            bookNode.ExpandAll();
            artNode.ExpandAll();
            textbookNode.ExpandAll();
        }




    }
}
