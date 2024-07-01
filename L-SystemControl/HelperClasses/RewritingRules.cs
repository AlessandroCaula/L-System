using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_SystemControl
{
    public class RewritingRules
    {
        #region Fields
        Dictionary<char, string> rewritingRulesDict;
        #endregion

        #region Properties
        public Dictionary<char, string> RewritingRulesDict
        {
            get { return rewritingRulesDict; }
        }
        #endregion

        #region Constructor
        public RewritingRules()
        {
            rewritingRulesDict = new Dictionary<char, string>();
        }
        #endregion

        #region Methods
        public void EmptyDictionary()
        {
            rewritingRulesDict.Clear();
        }

        public void AddToDictionary(char character, string function)
        {
            if (rewritingRulesDict.ContainsKey(character))
            {
                rewritingRulesDict[character] = function;
            }
            else
            {
                rewritingRulesDict.Add(character, function);
            }
        }
        #endregion
    }
}
