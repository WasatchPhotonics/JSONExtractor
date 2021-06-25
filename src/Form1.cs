using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace JSONExtractor
{
    public partial class Form1 : Form
    {
        IDictionary<string, object> treeRoot;

        BindingList<FilterAttribute> filterAttributes = new BindingList<FilterAttribute>();
        BindingList<ExtractAttribute> extractAttributes = new BindingList<ExtractAttribute>();
        BindingSource filterBindingSource;
        BindingSource extractBindingSource;

        Logger logger = Logger.getInstance();

        public Form1()
        {
            InitializeComponent();
            logger.setTextBox(textBoxEventLog);
            logger.level = Logger.LogLevel.DEBUG;

            filterBindingSource = new BindingSource(filterAttributes, null);
            extractBindingSource = new BindingSource(extractAttributes, null);

            dataGridViewAttributes.DataSource = extractAttributes;
            dataGridViewFilters.DataSource = filterAttributes;

            comboBoxExtractAttributeAggregateType.SelectedIndex = 0;
            comboBoxFilterType.SelectedIndex = 0;
        }

        private void buttonLoadSample_Click(object sender, EventArgs e)
        {
            treeRoot = null;
            treeViewJSON.Nodes.Clear();
            toolTip1.SetToolTip(buttonLoadSample, null);

            var result = openFileDialogSample.ShowDialog();
            if (result != DialogResult.OK)
                return;

            var samplePathname = openFileDialogSample.FileName;
            try
            {
                logger.info($"loading {samplePathname}");
                var jsonText = File.ReadAllText(samplePathname);
                treeRoot = JsonConvert.DeserializeObject<IDictionary<string, object>>(jsonText, new DictionaryConverter());
                toolTip1.SetToolTip(buttonLoadSample, samplePathname);
            }
            catch(Exception ex)
            {
                logger.error($"failed to load and parse {samplePathname}: {ex}");
                return;
            }

            treeViewJSON.Nodes.Add("Document");

            treeViewJSON.BeginUpdate();
            populateTreeView(treeRoot, treeViewJSON.Nodes[0]);
            treeViewJSON.EndUpdate();
        }

        // Traverse down the loaded JSON object tree starting at jsonNode, populating
        // the contents into the TreeView branch at treeNode.  It's not clear whether
        // we need to store the original value in the Tag.
        void populateTreeView(IDictionary<string, object> jsonNode, TreeNode treeNode)
        {
            foreach (string key in jsonNode.Keys)
            {
                object value = jsonNode[key];

                string type = value.GetType().ToString();
                if (value is IDictionary<string, object> dict)
                {
                    logger.debug($"recursing into {key}");
                    var node = treeNode.Nodes.Add(key);
                    populateTreeView(dict, node);
                }
                else if (value is List<object>)
                {
                    treeNode.Nodes.Add(key + "[]").Tag = value;
                }
                else
                {
                    logger.debug($"added scalar of type {type}");
                    treeNode.Nodes.Add(key).Tag = value;
                }
            }
        }

        private void buttonFilterAdd_Click(object sender, EventArgs e)
        {
            if (treeViewJSON.SelectedNode is null)
                return;

            var fa = new FilterAttribute()
            {
                jsonFullPath = treeViewJSON.SelectedNode.FullPath,
                filterType = (FilterAttribute.FilterType)Enum.Parse(typeof(FilterAttribute.FilterType), comboBoxFilterType.SelectedItem.ToString()),
                pattern = textBoxFilterPattern.Text
            };
            filterAttributes.Add(fa);
            filterBindingSource.ResetBindings(false);
            logger.debug("added FilterAttribute to filterAttributes");
        }

        private void buttonAttrAdd_Click(object sender, EventArgs e)
        {
            var tvn = treeViewJSON.SelectedNode;
            if (tvn is null)
                return;

            var ea = new ExtractAttribute()
            {
                label = textBoxExtractAttributeLabel.Text,
                jsonFullPath = treeViewJSON.SelectedNode.FullPath,
                defaultValue = textBoxExtractAttributeDefault.Text
            };

            if (tvn.Tag is List<object>)
            {
                logger.debug("AttrAdd: tag is list");
                ea.aggregateType = (ExtractAttribute.AggregateType)Enum.Parse(
                    typeof(ExtractAttribute.AggregateType),
                    comboBoxExtractAttributeAggregateType.SelectedItem.ToString());
            }
            else
                logger.debug("AttrAdd: tag is not list");

            extractAttributes.Add(ea);
            extractBindingSource.ResetBindings(false);
            logger.debug("added ExtractAttribute to extractAttributes");
        }

        private void treeViewJSON_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var tvn = treeViewJSON.SelectedNode;
            if (tvn is null)
            {
                buttonAddExtractAttribute.Enabled = 
                buttonFilterAdd.Enabled = false;
                return;
            }

            buttonAddExtractAttribute.Enabled = 
            buttonFilterAdd.Enabled = true;

            bool isList = tvn.Tag is List<object>;
            if (isList)
            {
                comboBoxExtractAttributeAggregateType.SelectedIndex = 0;
                comboBoxExtractAttributeAggregateType.Enabled = true;
            }
            else
            {
                // deselect any aggregate type
                logger.debug("treeViewClick: tag is not list ({0}, {1})", tvn.FullPath, tvn.Tag);
                comboBoxExtractAttributeAggregateType.SelectedIndex = -1;
                comboBoxExtractAttributeAggregateType.Enabled = false;
            }

            logger.debug("selected TreeView node {0}", treeViewJSON.SelectedNode.FullPath);

        }
    }
}
