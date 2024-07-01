using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_SystemControl
{
    public class LSystemGeneration
    {
        #region Fields
        public string lSystemString;
        #endregion


        #region Properties
        public string LSystemString
        {
            get { return lSystemString; }
            set { lSystemString = value; }
        }
        #endregion


        #region Constructor
        public LSystemGeneration()
        {
        }
        #endregion


        #region Methods
        public void AxiomSystemGeneration(string axiom, int nIterations, Dictionary<char, string> rewritingRules)
        {
            List<char> finalstringList = new List<char>();

            foreach (char s in axiom)
            {
                finalstringList.Add(s);
            }

            for (int i = 0; i < nIterations; i++)
            {
                List<char> lStringPerCycleList = new List<char>();

                foreach (char c in finalstringList)
                {
                    if (rewritingRules.ContainsKey(c))
                    {
                        foreach(char s in rewritingRules[c])
                        {
                            lStringPerCycleList.Add(s);
                        }
                    }
                    else
                    {
                        lStringPerCycleList.Add(c);
                    }
                }

                finalstringList = lStringPerCycleList;
            }

            this.lSystemString = new string(finalstringList.ToArray());
        }
        #endregion
    }
}


