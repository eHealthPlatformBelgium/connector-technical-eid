using System;

namespace connector_technical_eid {
    public class Identity
    {
        enum Gender
        {
            MALE, 
            FEMALE
        }
        enum DocumentType
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
        enum SpecialStatus
        {
            NO_STATUS, 
            WHITE_CANE, 
            EXTENDED_MINORITY, 
            WHITE_CANE_EXTENDED_MINORITY, 
            YELLOW_CANE, 
            YELLOW_CANE_EXTENDED_MINORITY
        }

        enum SpecialOrganisation
        {
            UNSPECIFIED, 
            SHAPE, NATO, 
            FORMER_BLUE_CARD_HOLDER, 
            RESEARCHER, 
            UNKNOWN
        }

        private string cardNumber;

        private string chipNumber;

        private DateTime cardValidityDateBegin;

        private DateTime cardValidityDateEnd;

        private string cardDeliveryMunicipality;

        private string nationalNumber;

        private string name;

        private string firstName;

        private string middleName;

        private string nationality;

        private string placeOfBirth;

        private DateTime dateOfBirth;

        private Gender gender;

        private string nobleCondition;

        private DocumentType documentType;

        private SpecialStatus specialStatus;

        private byte[] photoDigest;

        private string duplicate;

        private SpecialOrganisation specialOrganisation;

        private Boolean memberOfFamily;

        private byte[] data;

    }
}