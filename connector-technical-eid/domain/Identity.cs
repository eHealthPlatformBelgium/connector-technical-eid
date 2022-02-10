using System;

namespace connector_technical_eid {
    public class Identity
    {
        public enum Gender
        {
            MALE, 
            FEMALE
        }
       public enum DocumentType
        {
            BELGIAN_CITIZEN,
            KIDS_CARD,
            BOOTSTRAP_CARD,
            HABILITATION_CARD,
            FOREIGNER_A,
            FOREIGNER_B,
            FOREIGNER_C,
            FOREIGNER_D,
            FOREIGNER_E,
            FOREIGNER_E_PLUS,
            FOREIGNER_F,
            FOREIGNER_F_PLUS,
            EUROPEAN_BLUE_CARD_H,
            FOREIGNER_I,
            FOREIGNER_J,
            FOREIGNER_M,
            FOREIGNER_N,
            FOREIGNER_EU,
            FOREIGNER_EU_PLUS
        }
      public  enum SpecialStatus
        {
            NO_STATUS, 
            WHITE_CANE, 
            EXTENDED_MINORITY, 
            WHITE_CANE_EXTENDED_MINORITY, 
            YELLOW_CANE, 
            YELLOW_CANE_EXTENDED_MINORITY
        }

      public  enum SpecialOrganisation
        {
            UNSPECIFIED, 
            SHAPE, NATO, 
            FORMER_BLUE_CARD_HOLDER, 
            RESEARCHER, 
            UNKNOWN
        }

        public  string cardNumber;

        public  string chipNumber;

        public  DateTime cardValidityDateBegin;

        public  DateTime cardValidityDateEnd;

        public  string cardDeliveryMunicipality;

        public  string nationalNumber;

        public  string name;

        public  string firstName;

        public  string middleName;

        public  string nationality;

        public  string placeOfBirth;

        public  DateTime dateOfBirth;

        public  Gender gender;

        public  string nobleCondition;

        public  DocumentType documentType;

        public  SpecialStatus specialStatus;

        public  byte[] photoDigest;

        public  string duplicate;

        public  SpecialOrganisation specialOrganisation;

        public  Boolean memberOfFamily;

        public  byte[] data;
        public

        override String ToString()
        {
            return "name: " + name + " firstName: "+firstName;
        }

    }
}