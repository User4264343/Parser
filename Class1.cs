using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Parser
{
    /// <summary>
    /// Splitter opp en linje til en array. Default er å splitte ved whitespace, med følgende unntak: Ved splitting til streng med ikke-tom skilletegn, så må man angi mellomrom for å splitte ved whitespace.
    /// </summary>
    public class Parser
    {
        static Regex spaces = new Regex(@"\s+");
        TextReader rdr;
        string str;

        /// <summary>
        /// Splitter opp en linje fra filleseren.
        /// </summary>
        /// <param name="tr">Filinnholdet som skal splittes opp.</param>
        public Parser(TextReader tr)
        {
            rdr = tr;
        }
        /// <summary>
        /// Splitter opp en linje fra filleseren.
        /// </summary>
        /// <param name="sr">Filinnholdet som skal splittes opp.</param>
        public Parser(StreamReader sr)
        {
            rdr = sr;
        }
        /// <summary>
        /// Splitter opp en streng.
        /// </summary>
        /// <param name="s">Strengen som skal splittes opp.</param>
        public Parser(string s)
        {
            str = s;
        }
        /// <summary>
        /// Splitter opp et objekt.
        /// </summary>
        /// <param name="o">Objektet som skal splittes opp.</param>
        public Parser(object o)
        {
            if (o == null) str = null;
            else str = o.ToString();
        }


        /// <summary>
        /// Splitter en streng til en strengarray.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <returns>Den splittede strengen.</returns>
        public string[] ReadStrings(string skilleTegn)
        {
            char[] skilleTegnLi = new char[skilleTegn.Length];
            for (int i = 0; i < skilleTegn.Length; i++) skilleTegnLi[i] = skilleTegn[i];
            return ReadStrings(skilleTegnLi, false);
        }

        /// <summary>
        /// Splitter en streng til en strengarray. Adskiller er whitespace.
        /// </summary>
        /// <returns>Den splittede strengen.</returns>
        public string[] ReadStrings()
        {
            return ReadStrings(new char[] { }, false);
        }

        /// <summary>
        /// Splitter en streng til en strengarray. Adskiller er det angitte tegnet.
        /// </summary>
        /// <param name="skilleTegn">Adskillertegnet.</param>
        /// <returns>Den splittede strengen.</returns>
        public string[] ReadStrings(char skilleTegn)
        {
            return ReadStrings(new char[] { skilleTegn }, false);
        }

        /// <summary>
        /// Splitter en streng til en strengarray.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <returns>Den splittede strengen.</returns>
        public string[] ReadStrings(char[] skilleTegn)
        {
            return ReadStrings(skilleTegn, false);
            //bool mellomrom = false;
            //if (skilleTegn.Length == 0) mellomrom = true; //Default er å splitte ved whitespace.
            //else foreach (char s in skilleTegn) if (s == ' ') mellomrom = true;
            //string linje;
            //if (rdr != null) linje = rdr.ReadLine();
            //else linje = str;
            ////if (linje == null) return null; //Usikker på om jeg bør returnere null eller en tom array.
            //if (string.IsNullOrEmpty(linje)) return new string[] { };
            //string[] linjeLi;
            //if (mellomrom) {
            //    foreach (char s in skilleTegn) if (s != ' ') linje = linje.Replace(s, ' ');
            //    return spaces.Split(linje.Trim());
            //} else {
            //    int antallSkilleTegn = 0;
            //    foreach (char s in skilleTegn) {
            //        while (linje[0] == s) linje = linje.Remove(0, 1);
            //        while (linje[linje.Length - 1] == s) linje = linje.Remove(linje.Length - 1);
            //    }
            //    foreach (char s in skilleTegn) antallSkilleTegn += Funk.VerdiAntall(linje, s);
            //    linjeLi = new string[antallSkilleTegn+1];
            //    int start = 0;
            //    int teller = 0;
            //    foreach (char s in skilleTegn) {
            //        int i;
            //        for (i = 0; i < linje.Length; i++) {
            //            if (linje[i] == s) {
            //                linjeLi[teller++] = linje.Remove(i).Remove(0, start); //Kunne hatt .Trim() på slutten av linjen her, men har det ikke med for å øke fleksibiliteten.
            //                start = i+1;
            //            }
            //        }
            //        linjeLi[teller++] = linje.Remove(0, start).Trim();
            //    }
            //    return linjeLi;
            //}
        }

        /// <summary>
        /// Splitter en streng til en strengarray.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <param name="ignoreEscapedCharacters">Valgfri. true hvis man skal ignorere tegn som har en backslash (\) foran seg. Default er false.</param>
        /// <returns>Den splittede strengen.</returns>
        public string[] ReadStrings(string skilleTegn, bool ignoreEscapedCharacters)
        {
            char[] skilleTegnLi = new char[skilleTegn.Length];
            for (int i = 0; i < skilleTegn.Length; i++) skilleTegnLi[i] = skilleTegn[i];
            return ReadStrings(skilleTegnLi, ignoreEscapedCharacters);
        }

        /// <summary>
        /// Splitter en streng til en strengarray. Adskiller er whitespace.
        /// </summary>
        /// <param name="ignoreEscapedCharacters">Valgfri. true hvis man skal ignorere tegn som har en backslash (\) foran seg. Default er false.</param>
        /// <returns>Den splittede strengen.</returns>
        public string[] ReadStrings(bool ignoreEscapedCharacters)
        {
            return ReadStrings(new char[] { }, ignoreEscapedCharacters);
        }

        /// <summary>
        /// Splitter en streng til en strengarray. Adskiller er det angitte tegnet.
        /// </summary>
        /// <param name="skilleTegn">Adskillertegnet.</param>
        /// <param name="ignoreEscapedCharacters">Valgfri. true hvis man skal ignorere tegn som har en backslash (\) foran seg. Default er false.</param>
        /// <returns>Den splittede strengen.</returns>
        public string[] ReadStrings(char skilleTegn, bool ignoreEscapedCharacters)
        {
            return ReadStrings(new char[] { skilleTegn }, ignoreEscapedCharacters);
        }

        /// <summary>
        /// Splitter en streng til en strengarray.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <param name="ignoreEscapedCharacters">Valgfri. true hvis man skal ignorere tegn som har en backslash (\) foran seg. Default er false.</param>
        /// <returns>Den splittede strengen.</returns>
        public string[] ReadStrings(char[] skilleTegn, bool ignoreEscapedCharacters)
        {
            bool mellomrom = false;
            if (skilleTegn.Length == 0) mellomrom = true; //Default er å splitte ved whitespace.
            else foreach (char s in skilleTegn) if (s == ' ') mellomrom = true;
            string linje;
            if (rdr != null) linje = rdr.ReadLine();
            else linje = str;
            if (linje == null) return null; //Usikker på om jeg bør returnere null eller en tom array.
            if (linje == "") return new string[] { };
            string[] linjeLi;
            bool backslash;
            if (!ignoreEscapedCharacters) backslash = false;
            else backslash = linje.Contains("\\");
            if (mellomrom)
            {
                foreach (char s in skilleTegn)
                {
                    if (!backslash) linje = linje.Replace(s, ' ');
                    else
                    {
                        if (linje[0] == s) linje = linje.Remove(0, 1).Insert(0, " ");
                        for (int i = 1; i < linje.Length; i++)
                        {
                            if (linje[i] == s)
                            {
                                if (linje[i - 1] != '\\')
                                {
                                    linje = linje.Remove(i, 1).Insert(i, " ");
                                }
                            }
                        }
                    }
                }
                return spaces.Split(linje.Trim());
            }
            else
            {
                int antallSkilleTegn = 0;
                foreach (char s in skilleTegn)
                {
                    while (linje[0] == s) linje = linje.Remove(0, 1);
                    while (linje[linje.Length - 1] == s) linje = linje.Remove(linje.Length - 1);
                }
                foreach (char s in skilleTegn) foreach (char tegn in linje) if (tegn == s) antallSkilleTegn++;
                //foreach (char s in skilleTegn) antallSkilleTegn += Funk.TegnAntall(linje, s);
                linjeLi = new string[antallSkilleTegn + 1];
                int start = 0;
                int teller = 0;
                foreach (char s in skilleTegn)
                {
                    for (int i = 1; i < linje.Length; i++)
                    {
                        if (linje[i] == s)
                        {
                            if (!backslash || linje[i - 1] != '\\')
                            {
                                linjeLi[teller++] = linje.Remove(i).Remove(0, start); //Kunne hatt .Trim() på slutten av linjen her, men har det ikke med for å øke fleksibiliteten.
                                start = i + 1;
                            }
                        }
                    }
                    linjeLi[teller++] = linje.Remove(0, start).Trim();
                }
                if (teller < linjeLi.Length)
                { //Fjerner null-elementer.
                    string[] linjeLiTmp = linjeLi;
                    linjeLi = new string[teller];
                    for (int i = 0; i < teller; i++) linjeLi[i] = linjeLiTmp[i];
                }
                return linjeLi;
            }
        }

        /// <summary>
        /// Splitter en streng til array over flyttall.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <returns>Den splittede strengen som flyttall.</returns>
        public double[] ReadFloats(string skilleTegn)
        {
            return ReadFloats(skilleTegn, false);
        }
        /// <summary>
        /// Splitter en streng til array over flyttall.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <param name="ignorerFeil">true hvis metoden skal returnere de delene som den greier å parse til double's. Ellers vil det returneres null hvis det er 1+ elementer den ikke greier å parse. Default er false.</param>
        /// <returns>Den splittede strengen som flyttall.</returns>
        public double[] ReadFloats(string skilleTegn, bool ignorerFeil)
        {
            char[] skilleTegnLi = new char[skilleTegn.Length];
            for (int i = 0; i < skilleTegn.Length; i++) skilleTegnLi[i] = skilleTegn[i];
            return ReadFloats(skilleTegnLi, ignorerFeil);
        }

        /// <summary>
        /// Splitter en streng til array over flyttall. Adskiller er whitespace.
        /// </summary>
        /// <returns>Den splittede strengen som flyttall.</returns>
        public double[] ReadFloats()
        {
            return ReadFloats(false);
        }
        /// <summary>
        /// Splitter en streng til array over flyttall. Adskiller er whitespace.
        /// </summary>
        /// <param name="ignorerFeil">true hvis metoden skal returnere de delene som den greier å parse til double's. Ellers vil det returneres null hvis det er 1+ elementer den ikke greier å parse. Default er false.</param>
        /// <returns>Den splittede strengen som flyttall.</returns>
        public double[] ReadFloats(bool ignorerFeil)
        {
            return ReadFloats(new char[] { }, ignorerFeil);
        }

        /// <summary>
        /// Splitter en streng til array over flyttall. Adskiller er det angitte tegnet.
        /// </summary>
        /// <param name="skilleTegn">Adskillertegnet.</param>
        /// <returns>Den splittede strengen som flyttall.</returns>
        public double[] ReadFloats(char skilleTegn)
        {
            return ReadFloats(skilleTegn, false);
        }
        /// <summary>
        /// Splitter en streng til array over flyttall. Adskiller er det angitte tegnet.
        /// </summary>
        /// <param name="skilleTegn">Adskillertegnet.</param>
        /// <param name="ignorerFeil">true hvis metoden skal returnere de delene som den greier å parse til double's. Ellers vil det returneres null hvis det er 1+ elementer den ikke greier å parse. Default er false.</param>
        /// <returns>Den splittede strengen som flyttall.</returns>
        public double[] ReadFloats(char skilleTegn, bool ignorerFeil)
        {
            return ReadFloats(new char[] { skilleTegn }, ignorerFeil);
        }

        /// <summary>
        /// Splitter en streng til array over flyttall.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <returns>Den splittede strengen som flyttall.</returns>
        public double[] ReadFloats(char[] skilleTegn)
        {
            return ReadFloats(skilleTegn, false);
        }
        /// <summary>
        /// Splitter en streng til array over flyttall.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <param name="ignorerFeil">true hvis metoden skal returnere de delene som den greier å parse til double's. Ellers vil det returneres null hvis det er 1+ elementer den ikke greier å parse. Default er false.</param>
        /// <returns>Den splittede strengen som flyttall.</returns>
        public double[] ReadFloats(char[] skilleTegn, bool ignorerFeil)
        {
            //Legger til mellomromstegn siden talllister kan ikke inneholde mellomrom.
            char[] skilleTegnNy = (char[])skilleTegn.Clone();
            skilleTegnNy = new char[skilleTegn.Length + 1];
            skilleTegnNy[0] = ' ';
            for (int i = 0; i < skilleTegn.Length; i++) skilleTegnNy[i + 1] = skilleTegn[i];

            string[] felter = ReadStrings(skilleTegnNy);
            if (felter == null || felter.Length == 0) return new double[] { };
            System.Collections.Generic.List<double> obj = new System.Collections.Generic.List<double>();
            for (int i = 0; i < felter.Length; i++)
            {
                double tmp;
                if (double.TryParse(felter[i], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out tmp)) obj.Add(tmp);
                else if (double.TryParse(felter[i], out tmp)) obj.Add(tmp);
                else
                {
                    Console.WriteLine("Greide ikke å konvertere objekt nr " + (i + 1) + " (" + felter[i] + ") til double");
                    if (!ignorerFeil) return null;
                }
            }
            return obj.ToArray();
            //double[] obj = new double[felter.Length];
            //for (int i = 0; i < obj.Length; i++) {
            //    //if (fields[i].EndsWith(";")) fields[i] = fields[i].Substring(0, fields[i].Length - 1);
            //    //if (fields[i].EndsWith("+")) fields[i] = fields[i].Substring(0, fields[i].Length - 1);
            //    //Console.WriteLine(fields[i]);
            //    if (!double.TryParse(felter[i], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out obj[i])) if (!double.TryParse(felter[i], out obj[i])) Console.WriteLine("Greide ikke å konvertere objekt nr " + (i + 1) + " (" + felter[i] + ") til double");
            //    //obj[i] = double.Parse(fields[i], System.Globalization.CultureInfo.InvariantCulture);
            //}
            //return obj;
        }

        /// <summary>
        /// Splitter en streng til array over heltall.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <returns>Den splittede strengen som heltall.</returns>
        public int[] ReadInts(string skilleTegn)
        {
            return ReadInts(skilleTegn, false);
        }
        /// <summary>
        /// Splitter en streng til array over heltall.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <param name="ignorerFeil">true hvis metoden skal returnere de delene som den greier å parse til double's. Ellers vil det returneres null hvis det er 1+ elementer den ikke greier å parse. Default er false.</param>
        /// <returns>Den splittede strengen som heltall.</returns>
        public int[] ReadInts(string skilleTegn, bool ignorerFeil)
        {
            char[] skilleTegnLi = new char[skilleTegn.Length];
            for (int i = 0; i < skilleTegn.Length; i++) skilleTegnLi[i] = skilleTegn[i];
            return ReadInts(skilleTegnLi, ignorerFeil);
        }

        /// <summary>
        /// Splitter en streng til array over heltall. Adskiller er whitespace.
        /// </summary>
        /// <returns>Den splittede strengen som heltall.</returns>
        public int[] ReadInts()
        {
            return ReadInts(false);
        }
        /// <summary>
        /// Splitter en streng til array over heltall. Adskiller er whitespace.
        /// </summary>
        /// <param name="ignorerFeil">true hvis metoden skal returnere de delene som den greier å parse til double's. Ellers vil det returneres null hvis det er 1+ elementer den ikke greier å parse. Default er false.</param>
        /// <returns>Den splittede strengen som heltall.</returns>
        public int[] ReadInts(bool ignorerFeil)
        {
            return ReadInts(new char[] { }, ignorerFeil);
        }

        /// <summary>
        /// Splitter en streng til array over heltall. Adskiller er det angitte tegnet.
        /// </summary>
        /// <param name="skilleTegn">Adskillertegnet.</param>
        /// <returns>Den splittede strengen som heltall.</returns>
        public int[] ReadInts(char skilleTegn)
        {
            return ReadInts(skilleTegn, false);
        }
        /// <summary>
        /// Splitter en streng til array over heltall. Adskiller er det angitte tegnet.
        /// </summary>
        /// <param name="skilleTegn">Adskillertegnet.</param>
        /// <param name="ignorerFeil">true hvis metoden skal returnere de delene som den greier å parse til double's. Ellers vil det returneres null hvis det er 1+ elementer den ikke greier å parse. Default er false.</param>
        /// <returns>Den splittede strengen som heltall.</returns>
        public int[] ReadInts(char skilleTegn, bool ignorerFeil)
        {
            return ReadInts(new char[] { skilleTegn }, ignorerFeil);
        }

        /// <summary>
        /// Splitter en streng til array over heltall.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <returns>Den splittede strengen som heltall.</returns>
        public int[] ReadInts(char[] skilleTegn)
        {
            return ReadInts(skilleTegn, false);
        }
        /// <summary>
        /// Splitter en streng til array over heltall.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <param name="ignorerFeil">true hvis metoden skal returnere de delene som den greier å parse til double's. Ellers vil det returneres null hvis det er 1+ elementer den ikke greier å parse. Default er false.</param>
        /// <returns>Den splittede strengen som heltall.</returns>
        public int[] ReadInts(char[] skilleTegn, bool ignorerFeil)
        {
            //Legger til mellomromstegn siden talllister kan ikke inneholde mellomrom.
            char[] skilleTegnNy = (char[])skilleTegn.Clone();
            skilleTegnNy = new char[skilleTegn.Length + 1];
            skilleTegnNy[0] = ' ';
            for (int i = 0; i < skilleTegn.Length; i++) skilleTegnNy[i + 1] = skilleTegn[i];

            string[] felter = ReadStrings(skilleTegnNy);
            if (felter == null || felter.Length == 0) return new int[] { };
            System.Collections.Generic.List<int> obj = new System.Collections.Generic.List<int>();
            int tmp;
            for (int i = 0; i < felter.Length; i++)
            {
                if (int.TryParse(felter[i], out tmp)) obj.Add(tmp);
                else
                {
                    Console.WriteLine("Greide ikke å konvertere objekt nr " + (i + 1) + " (" + felter[i] + ") til integer");
                    if (!ignorerFeil) return null;
                }
            }
            //for (int i = 0; i < obj.Length; i++) if (!int.TryParse(felter[i], out obj[i])) Console.WriteLine("Greide ikke å konvertere objekt nr " + (i + 1) + " (" + felter[i] + ") til integer");
            return obj.ToArray();
        }


        /// <summary>
        /// Splitter en streng til array over bytes.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <returns>Den splittede strengen som bytes.</returns>
        public byte[] ReadBytes(string skilleTegn)
        {
            return ReadBytes(skilleTegn, false);
        }
        /// <summary>
        /// Splitter en streng til array over bytes.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <param name="ignorerFeil">true hvis metoden skal returnere de delene som den greier å parse til double's. Ellers vil det returneres null hvis det er 1+ elementer den ikke greier å parse. Default er false.</param>
        /// <returns>Den splittede strengen som bytes.</returns>
        public byte[] ReadBytes(string skilleTegn, bool ignorerFeil)
        {
            char[] skilleTegnLi = new char[skilleTegn.Length];
            for (int i = 0; i < skilleTegn.Length; i++) skilleTegnLi[i] = skilleTegn[i];
            return ReadBytes(skilleTegnLi, ignorerFeil);
        }

        /// <summary>
        /// Splitter en streng til array over bytes. Adskiller er whitespace.
        /// </summary>
        /// <returns>Den splittede strengen som bytes.</returns>
        public byte[] ReadBytes()
        {
            return ReadBytes(false);
        }
        /// <summary>
        /// Splitter en streng til array over bytes. Adskiller er whitespace.
        /// </summary>
        /// <param name="ignorerFeil">true hvis metoden skal returnere de delene som den greier å parse til double's. Ellers vil det returneres null hvis det er 1+ elementer den ikke greier å parse. Default er false.</param>
        /// <returns>Den splittede strengen som bytes.</returns>
        public byte[] ReadBytes(bool ignorerFeil)
        {
            return ReadBytes(new char[] { }, ignorerFeil);
        }

        /// <summary>
        /// Splitter en streng til array over bytes. Adskiller er det angitte tegnet.
        /// </summary>
        /// <param name="skilleTegn">Adskillertegnet.</param>
        /// <returns>Den splittede strengen som bytes.</returns>
        public byte[] ReadBytes(char skilleTegn)
        {
            return ReadBytes(skilleTegn, false);
        }
        /// <summary>
        /// Splitter en streng til array over bytes. Adskiller er det angitte tegnet.
        /// </summary>
        /// <param name="skilleTegn">Adskillertegnet.</param>
        /// <param name="ignorerFeil">true hvis metoden skal returnere de delene som den greier å parse til double's. Ellers vil det returneres null hvis det er 1+ elementer den ikke greier å parse. Default er false.</param>
        /// <returns>Den splittede strengen som bytes.</returns>
        public byte[] ReadBytes(char skilleTegn, bool ignorerFeil)
        {
            return ReadBytes(new char[] { skilleTegn }, ignorerFeil);
        }

        /// <summary>
        /// Splitter en streng til array over bytes.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <returns>Den splittede strengen som bytes.</returns>
        public byte[] ReadBytes(char[] skilleTegn)
        {
            return ReadBytes(skilleTegn, false);
        }
        /// <summary>
        /// Splitter en streng til array over bytes.
        /// </summary>
        /// <param name="skilleTegn">Hvert tegn her brukes som adskiller.</param>
        /// <param name="ignorerFeil">true hvis metoden skal returnere de delene som den greier å parse til double's. Ellers vil det returneres null hvis det er 1+ elementer den ikke greier å parse. Default er false.</param>
        /// <returns>Den splittede strengen som bytes.</returns>
        public byte[] ReadBytes(char[] skilleTegn, bool ignorerFeil)
        {
            //Legger til mellomromstegn siden talllister kan ikke inneholde mellomrom.
            char[] skilleTegnNy = (char[])skilleTegn.Clone();
            skilleTegnNy = new char[skilleTegn.Length + 1];
            skilleTegnNy[0] = ' ';
            for (int i = 0; i < skilleTegn.Length; i++) skilleTegnNy[i + 1] = skilleTegn[i];

            string[] felter = ReadStrings(skilleTegnNy);
            if (felter == null || felter.Length == 0) return new byte[] { };
            System.Collections.Generic.List<byte> obj = new System.Collections.Generic.List<byte>();
            byte tmp;
            for (int i = 0; i < felter.Length; i++)
            {
                if (byte.TryParse(felter[i], out tmp)) obj.Add(tmp);
                else
                {
                    Console.WriteLine("Greide ikke å konvertere objekt nr " + (i + 1) + " (" + felter[i] + ") til byte");
                    if (!ignorerFeil) return null;
                }
            }
            //for (int i = 0; i < obj.Length; i++) if (!int.TryParse(felter[i], out obj[i])) Console.WriteLine("Greide ikke å konvertere objekt nr " + (i + 1) + " (" + felter[i] + ") til integer");
            return obj.ToArray();
        }
    }
}
