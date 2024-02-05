using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaNiBaaStra.Utilities
{
    public class HouseData
    {
        public static string GetHouseData(int houseNumber)
        {
            switch(houseNumber)
            {
                case 9:
                    return "fortune, prosperity, morals, philosophy, righteousness, \r\nhigher studies, Vedic Astrology, your guru, faith in God, religion, and Spirituality";
                case 5:
                    return "intelligence, spiritual tendencies, creativity, romance, \r\nchildren, speculation, and even gambling";
                case 1:
                    return "shows the very beginning of everything and thus signifies the\r\n soul. It is the inviiśible driving force that keeps us going in \r\nlife and urges us to choose specific directions and make certain choices";
                case 2:
                    return "gains, profits, aspirations, wishes, desires, the fulfillment of \r\naspirations, recovery from hardships, fruits of discipline, the celebration of auspicious \r\nevents, communities, friends, elder siblings, large networks";
                case 12:
                    return "salvation – Moksha,spiritual awakening – enlightenment,foreign lands \r\n& settlement,religious journeys,expenditure,charities,long-term investments,repayment \r\nof debt,bedroom activities, sleeping, dreaming";
                case 8:
                    return "hidden treasures, spirituality, hidden or occult knowledge, transformations,\r\n death, rebirth, and unexpected gains";
                case 4:
                    return "real estate, property, vehicles, conveyances, mother, peace of mind";
                case 3:
                    return "valor, courage, motivation, skills, efforts, ability to take action, hobbies, \r\nshort travels, mental strength & intellect, written & verbal communication,\r\n communication technologies, as well as cousins, younger siblings";
                case 10:
                    return "karma or main duties in life, responsibilities, karma, profession, \r\norder & regulations, midheaven & brightest point in life, public life, high achievements, \r\nsocial rank & status, honor, high authority";
                case 11:
                    return "gains, profits, aspirations, wishes, desires, the fulfillment of aspirations,\r\n recovery from hardships, fruits of discipline, the celebration of auspicious events, \r\ncommunities, friends, elder siblings, large networks";
                case 7:
                    return "relationship, marriage, spouse or life partner, all kind of partnerships, venture\r\n partners, marketplaces, trading, entrepreneurship, as well as, balance, peace, harmony, \r\ncompassion, compromise, equity, justice, society, societal norms";
            }
            return "";
        }
    }
}
