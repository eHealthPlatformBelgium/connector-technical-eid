using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using static connector_technical_eid.Identity;

namespace connector_technical_eid
{
    internal static class TLV
    {
        public static IDictionary<byte, byte[]> Parse(this byte[] file)
        {
            var i = 0;
            var retVal = new Dictionary<byte, byte[]>();
            while (i < file.Length - 1)
            {
                var tag = file[i++];
                if (tag == 0) break;

                var len = 0;
                byte lenByte;
                do
                {
                    lenByte = file[i++];
                    len = (len << 7) + (lenByte & 0x7F);
                } while ((lenByte & 0x08) == 0x80);

                var val = new byte[len];
                Array.Copy(file, i, val, 0, len);
                retVal.Add(tag, val);
                i += len;
            }

            return retVal;
        }

        public static string ToStr(this byte[] value)
        {
            return Encoding.UTF8.GetString(value).TrimEnd();
        }

        public static string ToHex(this byte[] value)
        {
            return BitConverter.ToString(value).Replace("-", "");
        }

        public static DateTime ToDate(this byte[] value)
        {
            var date = value.ToStr().Replace(" ", "").Replace(".", "");
            return DateTime.ParseExact(date, "ddMMyyyy", CultureInfo.InvariantCulture);
        }

        public static DateTime ToBirthDate(this byte[] value)
        {
            var stringValue = value.ToStr();
            var parts = stringValue.Split(new[] {'.', ' '}, StringSplitOptions.RemoveEmptyEntries); //split on . and ' '
            if (parts.Length != 3) throw new InvalidOperationException("Invalid Birth Date: " + stringValue);
            var year = int.Parse(parts[2]);
            var month = parts[1].ToMonth();
            var day = int.Parse(parts[0]);
            return new DateTime(year, month, day);
        }

        private static int ToMonth(this string value)
        {
            switch (value)
            {
                case "JAN":
                    return 1;
                case "FEB":
                case "FEV":
                    return 2;
                case "MÄR":
                case "MARS":
                case "MAAR":
                    return 3;
                case "APR":
                case "AVR":
                    return 4;
                case "MAI":
                case "MEI":
                    return 5;
                case "JUIN":
                case "JUN":
                    return 6;
                case "JUIL":
                case "JUL":
                    return 7;
                case "AOUT":
                case "AUG":
                    return 8;
                case "SEPT":
                case "SEP":
                    return 9;
                case "OCT":
                case "OKT":
                    return 10;
                case "NOV":
                    return 11;
                case "DEC":
                case "DEZ":
                    return 12;
                default:
                    throw new InvalidOperationException("Unknown Birth Month: " + value);
            }
        }

        public static Gender ToGender(this byte[] value)
        {
            switch (value.ToStr())
            {
                case "M":
                    return Gender.MALE;
                case "V":
                case "F":
                case "W":
                    return Gender.FEMALE;
                default:
                    throw new InvalidOperationException("Unknown Gender: " + value.ToStr());
            }
        }

        public static DocumentType ToDocType(this byte[] value)
        {
            switch (value.ToStr())
            {
                case "1":
                case "01":
                    return DocumentType.BELGIAN_CITIZEN;
                case "6":
                case "06":
                    return DocumentType.KIDS_CARD;
                case "7":
                case "07":
                    return DocumentType.BOOTSTRAP_CARD;
                case "8":
                case "08":
                    return DocumentType.HABILITATION_CARD;
                case "11":
                    return DocumentType.FOREIGNER_A;
                case "12":
                    return DocumentType.FOREIGNER_B;
                case "13":
                    return DocumentType.FOREIGNER_C;
                case "14":
                    return DocumentType.FOREIGNER_D;
                case "15":
                    return DocumentType.FOREIGNER_E;
                case "16":
                    return DocumentType.FOREIGNER_E_PLUS;
                case "17":
                    return DocumentType.FOREIGNER_F;
                case "18":
                    return DocumentType.FOREIGNER_F_PLUS;
                case "19":
                    return DocumentType.EUROPEAN_BLUE_CARD_H;
                case "20":
                    return DocumentType.FOREIGNER_I;
                case "21":
                    return DocumentType.FOREIGNER_J;
                case "22":
                    return DocumentType.FOREIGNER_M;
                case "23":
                    return DocumentType.FOREIGNER_N;
                case "31":
                    return DocumentType.FOREIGNER_EU;
                case "32":
                    return DocumentType.FOREIGNER_EU_PLUS;
                default:
                    throw new InvalidOperationException("Unknown Document Type: " + value.ToStr());
            }
        }

        public static SpecialStatus ToSpec(this byte[] value)
        {
            switch (value.ToStr())
            {
                case "0":
                    return SpecialStatus.NO_STATUS;
                case "1":
                    return SpecialStatus.WHITE_CANE;
                case "2":
                    return SpecialStatus.EXTENDED_MINORITY;
                case "3":
                    return SpecialStatus.WHITE_CANE_EXTENDED_MINORITY;
                case "4":
                    return SpecialStatus.YELLOW_CANE;
                case "5":
                    return SpecialStatus.YELLOW_CANE_EXTENDED_MINORITY;
                default:
                    throw new InvalidOperationException("Unknown Spec: " + value.ToStr());
            }
        }

        public static SpecialOrganisation ToSpecialOrganisation(this byte[] value)
        {
            switch (value.ToStr())
            {
                case "1":
                    return SpecialOrganisation.SHAPE;
                case "2":
                    return SpecialOrganisation.NATO;
                case "4":
                    return SpecialOrganisation.FORMER_BLUE_CARD_HOLDER;
                case "5":
                    return SpecialOrganisation.RESEARCHER;
                default:
                    return SpecialOrganisation.UNSPECIFIED;
            }
        }
    }
}