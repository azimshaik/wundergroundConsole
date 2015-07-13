using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net;
using System.IO;

namespace Wunderground_Console
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Wunderground API test ");
            string wunderground_key = "32976a8a62f1d2ae";
            string[] stateArray = { "OH", "NY", "NC" };
            string[] temperatHigh = new string[20];
            string[] temperatLow = new string[20];
            int tempHi = 0;
            int tempLow = 0;
            string abc = string.Empty;

            //complete array of cities in Ohio
            string[] cityArray1 = { "ABERDEEN", "ADA", "ADAMSVILLE", "ADDYSTON", "ADELPHI", "ADENA", "AKRON", "ALBANY", "ALEXANDRIA", "ALGER", "ALLIANCE", "ALVORDTON", "AMANDA", "AMBERLEY", "AMELIA", "AMESVILLE", "AMHERST", "AMSTERDAM", "ANDOVER", "ANNA", "ANSONIA", "ANTIOCH", "ANTWERP", "APPLE CREEK", "AQUILLA", "ARCADIA", "ARCANUM", "ARCHBOLD", "ARLINGTON", "ARLINGTON HEIGHTS", "ASHLAND", "ASHLEY", "ASHTABULA", "ASHVILLE", "ATHALIA", "ATHENS", "ATTICA", "AURORA", "AUSTINTOWN", "AVON", "AVON LAKE", "BAILEY LAKES", "BAINBRIDGE", "BAINBRIDGE", "BAIRDSTOWN", "BALLVILLE", "BALTIC", "BALTIMORE", "BARBERTON", "BARNESVILLE", "BARNHILL", "BATAVIA", "BATESVILLE", "BAY VIEW", "BAY VILLAGE", "BEACH CITY", "BEACHWOOD", "BEALLSVILLE", "BEAVER", "BEAVERCREEK", "BEAVERDAM", "BECKETT RIDGE", "BEDFORD", "BEDFORD HEIGHTS", "BEECHWOOD TRAILS", "BELLAIRE", "BELLBROOK", "BELLE CENTER", "BELLEFONTAINE", "BELLE VALLEY", "BELLEVUE", "BELLVILLE", "BELMONT", "BELMORE", "BELOIT", "BELPRE", "BENTLEYVILLE", "BENTON RIDGE", "BEREA", "BERGHOLZ", "BERKEY", "BERLIN HEIGHTS", "BETHEL", "BETHESDA", "BETTSVILLE", "BEVERLY", "BEXLEY", "BLACKLICK ESTATES", "BLAKESLEE", "BLANCHESTER", "BLOOMDALE", "BLOOMINGBURG", "BLOOMINGDALE", "BLOOMVILLE", "BLUE ASH", "BLUFFTON", "BOARDMAN", "BOLINDALE", "BOLIVAR", "BOSTON HEIGHTS", "BOTKINS", "BOWERSTON", "BOWERSVILLE", "BOWLING GREEN", "BRADFORD", "BRADNER", "BRADY LAKE", "BRATENAHL", "BRECKSVILLE", "BREMEN", "BREWSTER", "BRICE", "BRIDGEPORT", "BRIDGETOWN NORTH", "BRIMFIELD", "BROADVIEW HEIGHTS", "BROOKFIELD CENTER", "BROOKLYN", "BROOKLYN HEIGHTS", "BROOK PARK", "BROOKSIDE", "BROOKVILLE", "BROUGHTON", "BRUNSWICK", "BRYAN", "BUCHTEL", "BUCKEYE LAKE", "BUCKLAND", "BUCYRUS", "BURBANK", "BURGOON", "BURKETTSVILLE", "BURLINGTON", "BURTON", "BUTLER", "BUTLERVILLE", "BYESVILLE", "CADIZ", "CAIRO", "CALCUTTA", "CALDWELL", "CALEDONIA", "CAMBRIDGE", "CAMDEN", "CAMPBELL", "CANAL FULTON", "CANAL WINCHESTER", "CANFIELD", "CANTON", "CARDINGTON", "CAREY", "CARLISLE", "CARROLL", "CARROLLTON", "CASSTOWN", "CASTALIA", "CASTINE", "CATAWBA", "CECIL", "CEDARVILLE", "CELINA", "CENTERBURG", "CENTERVILLE", "CENTERVILLE", "CHAGRIN FALLS", "CHAMPION HEIGHTS", "CHARDON", "CHATFIELD", "CHAUNCEY", "CHERRY FORK", "CHERRY GROVE", "CHESAPEAKE", "CHESHIRE", "CHESTERHILL", "CHESTERLAND", "CHESTERVILLE", "CHEVIOT", "CHICKASAW", "CHILLICOTHE", "CHILO", "CHIPPEWA LAKE", "CHOCTAW LAKE", "CHRISTIANSBURG", "CHURCHILL", "CINCINNATI", "CIRCLEVILLE", "CLARINGTON", "CLARKSBURG", "CLARKSVILLE", "CLAY CENTER", "CLAYTON", "CLEVELAND", "CLEVELAND HEIGHTS", "CLEVES", "CLIFTON", "CLINTON", "CLOVERDALE", "CLYDE", "COAL GROVE", "COALTON", "COLDWATER", "COLLEGE CORNER", "COLUMBIANA", "COLUMBUS", "COLUMBUS GROVE", "COMMERCIAL POINT", "CONESVILLE", "CONGRESS", "CONNEAUT", "CONTINENTAL", "CONVOY", "COOLVILLE", "CORNING", "CORTLAND", "CORWIN", "COSHOCTON", "COVEDALE", "COVINGTON", "CRAIG BEACH", "CRESTLINE", "CRESTON", "CRIDERSVILLE", "CROOKSVILLE", "CROWN CITY", "CRYSTAL LAKES", "CUMBERLAND", "CUSTAR", "CUYAHOGA FALLS", "CUYAHOGA HEIGHTS", "CYGNET", "DALTON", "DANVILLE", "DARBYVILLE", "DAY HEIGHTS", "DAYTON", "DEER PARK", "DEERSVILLE", "DEFIANCE", "DE GRAFF", "DELAWARE", "DELLROY", "DELPHOS", "DELTA", "DENNISON", "DENT", "DESHLER", "DEVOLA", "DEXTER CITY", "DILLONVALE", "DILLONVALE", "DONNELSVILLE", "DOVER", "DOYLESTOWN", "DRESDEN", "DREXEL", "DRY RUN", "DUBLIN", "DUNKIRK", "DUPONT", "EAST CANTON", "EAST CLEVELAND", "EASTLAKE", "EAST LIVERPOOL", "EAST PALESTINE", "EAST SPARTA", "EATON", "EATON ESTATES", "EDGERTON", "EDGEWOOD", "EDISON", "EDON", "ELDORADO", "ELGIN", "ELIDA", "ELMORE", "ELMWOOD PLACE", "ELYRIA", "EMPIRE", "ENGLEWOOD", "ENON", "EUCLID", "EVENDALE", "FAIRBORN", "FAIRFAX", "FAIRFIELD", "FAIRFIELD BEACH", "FAIRLAWN", "FAIRPORT HARBOR", "FAIRVIEW", "FAIRVIEW LANES", "FAIRVIEW PARK", "FARMERSVILLE", "FAYETTE", "FAYETTEVILLE", "FELICITY", "FINDLAY", "FINNEYTOWN", "FIVE POINTS", "FLETCHER", "FLORIDA", "FLUSHING", "FOREST", "FOREST PARK", "FORESTVILLE", "FORT JENNINGS", "FORT LORAMIE", "FORT MCKINLEY", "FORT RECOVERY", "FORT SHAWNEE", "FOSTORIA", "FRANKFORT", "FRANKLIN", "FRANKLIN FURNACE", "FRAZEYSBURG", "FREDERICKSBURG", "FREDERICKTOWN", "FREEPORT", "FREMONT", "FRUIT HILL", "FULTON", "FULTONHAM", "GAHANNA", "GALENA", "GALION", "GALLIPOLIS", "GAMBIER", "GANN", "GARFIELD HEIGHTS", "GARRETTSVILLE", "GATES MILLS", "GENEVA", "GENEVA-ON-THE-LAKE", "GENOA", "GEORGETOWN", "GERMANTOWN", "GETTYSBURG", "GIBSONBURG", "GILBOA", "GIRARD", "GLANDORF", "GLENDALE", "GLENFORD", "GLENMONT", "GLENMOOR", "GLENWILLOW", "GLORIA GLENS PARK", "GLOUSTER", "GNADENHUTTEN", "GOLF MANOR", "GORDON", "GRAFTON", "GRAND RAPIDS", "GRAND RIVER", "GRANDVIEW", "GRANDVIEW HEIGHTS", "GRANVILLE", "GRANVILLE SOUTH", "GRATIOT", "GRATIS", "GRAYSVILLE", "GREEN", "GREEN CAMP", "GREENFIELD", "GREENHILLS", "GREEN MEADOWS", "GREEN SPRINGS", "GREENTOWN", "GREENVILLE", "GREENWICH", "GROESBECK", "GROVE CITY", "GROVEPORT", "GROVER HILL", "HAMDEN", "HAMERSVILLE", "HAMILTON", "HAMLER", "HANGING ROCK", "HANOVER", "HANOVERTON", "HARBOR HILLS", "HARBOR VIEW", "HARPSTER", "HARRISBURG", "HARRISON", "HARRISVILLE", "HARROD", "HARTFORD", "HARTVILLE", "HARVEYSBURG", "HASKINS", "HAVILAND", "HAYESVILLE", "HEATH", "HEBRON", "HELENA", "HEMLOCK", "HICKSVILLE", "HIGGINSPORT", "HIGHLAND", "HIGHLAND HEIGHTS", "HIGHLAND HILLS", "HILLIARD", "HILLS AND DALES", "HILLSBORO", "HILLTOP", "HIRAM", "HOLGATE", "HOLIDAY CITY", "HOLIDAY VALLEY", "HOLLAND", "HOLLANSBURG", "HOLLOWAY", "HOLMESVILLE", "HOPEDALE", "HOWLAND CENTER", "HOYTVILLE", "HUBBARD", "HUBER HEIGHTS", "HUBER RIDGE", "HUDSON", "HUNTER", "HUNTING VALLEY", "HUNTSVILLE", "HURON", "INDEPENDENCE", "IRONDALE", "IRONTON", "ITHACA", "JACKSON", "JACKSONBURG", "JACKSON CENTER", "JACKSONVILLE", "JAMESTOWN", "JEFFERSON", "JEFFERSONVILLE", "JENERA", "JEROMESVILLE", "JERRY CITY", "JERUSALEM", "JEWETT", "JOHNSTOWN", "JUNCTION CITY", "KALIDA", "KELLEYS ISLAND", "KENT", "KENTON", "KENWOOD", "KETTERING", "KETTLERSVILLE", "KILLBUCK", "KIMBOLTON", "KINGSTON", "KIPTON", "KIRBY", "KIRKERSVILLE", "KIRTLAND", "KIRTLAND HILLS", "LA CROFT", "LAFAYETTE", "LAGRANGE", "LAKE DARBY", "LAKELINE", "LAKEMORE", "LAKEVIEW", "LAKEWOOD", "LANCASTER", "LANDEN", "LA RUE", "LATTY", "LAURA", "LAURELVILLE", "LAWRENCEVILLE", "LEAVITTSBURG", "LEBANON", "LEESBURG", "LEESVILLE", "LEETONIA", "LEIPSIC", "LEWISBURG", "LEWISVILLE", "LEXINGTON", "LIBERTY CENTER", "LIMA", "LIMAVILLE", "LINCOLN HEIGHTS", "LINCOLN VILLAGE", "LINDSEY", "LINNDALE", "LISBON", "LITHOPOLIS", "LOCKBOURNE", "LOCKINGTON", "LOCKLAND", "LODI", "LOGAN", "LOGAN ELM VILLAGE", "LONDON", "LORAIN", "LORDSTOWN", "LORE CITY", "LOUDONVILLE", "LOUISVILLE", "LOVELAND", "LOVELAND PARK", "LOWELL", "LOWELLVILLE", "LOWER SALEM", "LUCAS", "LUCASVILLE", "LUCKEY", "LUDLOW FALLS", "LYNCHBURG", "LYNDHURST", "LYONS", "MCARTHUR", "MCCLURE", "MCCOMB", "MCCONNELSVILLE", "MCDONALD", "MACEDONIA", "MCGUFFEY", "MACK NORTH", "MACKSBURG", "MACK SOUTH", "MADEIRA", "MADISON", "MAGNETIC SPRINGS", "MAGNOLIA", "MAINEVILLE", "MALINTA", "MALTA", "MALVERN", "MANCHESTER", "MANSFIELD", "MANTUA", "MAPLE HEIGHTS", "MAPLE RIDGE", "MAPLEWOOD PARK", "MARBLE CLIFF", "MARBLEHEAD", "MARENGO", "MARIEMONT", "MARIETTA", "MARION", "MARSEILLES", "MARSHALLVILLE", "MARTINSBURG", "MARTINS FERRY", "MARTINSVILLE", "MARYSVILLE", "MASON", "MASSILLON", "MASURY", "MATAMORAS", "MAUMEE", "MAYFIELD", "MAYFIELD HEIGHTS", "MECHANICSBURG", "MEDINA", "MELROSE", "MENDON", "MENTOR", "MENTOR-ON-THE-LAKE", "METAMORA", "MEYERS LAKE", "MIAMISBURG", "MIDDLEBURG HEIGHTS", "MIDDLEFIELD", "MIDDLE POINT", "MIDDLEPORT", "MIDDLETOWN", "MIDLAND", "MIDVALE", "MIDWAY", "MIFFLIN", "MILAN", "MILFORD", "MILFORD CENTER", "MILLBURY", "MILLEDGEVILLE", "MILLER CITY", "MILLERSBURG", "MILLERSPORT", "MILLVILLE", "MILTON CENTER", "MILTONSBURG", "MINERAL CITY", "MINERAL RIDGE", "MINERVA", "MINERVA PARK", "MINGO JUNCTION", "MINSTER", "MOGADORE", "MONFORT HEIGHTS EAST", "MONFORT HEIGHTS SOUTH", "MONROE", "MONROEVILLE", "MONTEZUMA", "MONTGOMERY", "MONTPELIER", "MONTROSE-GHENT", "MORAINE", "MORELAND HILLS", "MORRAL", "MORRISTOWN", "MORROW", "MOSCOW", "MOUNT BLANCHARD", "MOUNT CARMEL", "MOUNT CORY", "MOUNT EATON", "MOUNT GILEAD", "MOUNT HEALTHY", "MOUNT HEALTHY HEIGHTS", "MOUNT ORAB", "MOUNT PLEASANT", "MOUNT REPOSE", "MOUNT STERLING", "MOUNT VERNON", "MOUNT VICTORY", "MOWRYSTOWN", "MULBERRY", "MUNROE FALLS", "MURRAY CITY", "MUTUAL", "NAPOLEON", "NASHVILLE", "NAVARRE", "NEFFS", "NELLIE", "NELSONVILLE", "NEVADA", "NEVILLE", "NEW ALBANY", "NEW ALEXANDRIA", "NEWARK", "NEW ATHENS", "NEW BAVARIA", "NEW BLOOMINGTON", "NEW BOSTON", "NEW BREMEN", "NEWBURGH HEIGHTS", "NEW CARLISLE", "NEWCOMERSTOWN", "NEW CONCORD", "NEW FRANKLIN", "NEW HOLLAND", "NEW KNOXVILLE", "NEW LEBANON", "NEW LEXINGTON", "NEW LONDON", "NEW MADISON", "NEW MIAMI", "NEW MIDDLETOWN", "NEW PARIS", "NEW PHILADELPHIA", "NEW RICHMOND", "NEW RIEGEL", "NEW ROME", "NEW STRAITSVILLE", "NEWTON FALLS", "NEWTONSVILLE", "NEWTOWN", "NEW VIENNA", "NEW WASHINGTON", "NEW WATERFORD", "NEW WESTON", "NEY", "NILES", "NORTH BALTIMORE", "NORTH BEND", "NORTHBROOK", "NORTH CANTON", "NORTH COLLEGE HILL", "NORTH FAIRFIELD", "NORTHFIELD", "NORTH FORK VILLAGE", "NORTHGATE", "NORTH HAMPTON", "NORTH KINGSVILLE", "NORTH LEWISBURG", "NORTH MADISON", "NORTH OLMSTED", "NORTH PERRY", "NORTH RANDALL", "NORTHRIDGE", "NORTHRIDGE", "NORTH RIDGEVILLE", "NORTH ROBINSON", "NORTH ROYALTON", "NORTH STAR", "NORTHWOOD", "NORTH ZANESVILLE", "NORTON", "NORWALK", "NORWICH", "NORWOOD", "OAK HARBOR", "OAK HILL", "OAKWOOD", "OAKWOOD", "OAKWOOD", "OBERLIN", "OBETZ", "OCTA", "OHIO CITY", "OLDE WEST CHESTER", "OLD WASHINGTON", "OLMSTED FALLS", "ONTARIO", "ORANGE", "ORANGEVILLE", "OREGON", "ORIENT", "ORRVILLE", "ORWELL", "OSGOOD", "OSTRANDER", "OTTAWA", "OTTAWA HILLS", "OTTOVILLE", "OTWAY", "OWENSVILLE", "OXFORD", "PAINESVILLE", "PALESTINE", "PANDORA", "PARK LAYNE", "PARMA", "PARMA HEIGHTS", "PARRAL", "PATASKALA", "PATTERSON", "PAULDING", "PAYNE", "PEEBLES", "PEMBERVILLE", "PENINSULA", "PEPPER PIKE", "PERRY", "PERRY HEIGHTS", "PERRYSBURG", "PERRYSVILLE", "PHILLIPSBURG", "PHILO", "PICKERINGTON", "PIGEON CREEK", "PIKETON", "PIONEER", "PIQUA", "PITSBURG", "PLAIN CITY", "PLAINFIELD", "PLEASANT CITY", "PLEASANT GROVE", "PLEASANT HILL", "PLEASANT PLAIN", "PLEASANT RUN", "PLEASANT RUN FARM", "PLEASANTVILLE", "PLYMOUTH", "POLAND", "POLK", "POMEROY", "PORTAGE", "PORTAGE LAKES", "PORT CLINTON", "PORT JEFFERSON", "PORTSMOUTH", "PORT WASHINGTON", "PORT WILLIAM", "POTSDAM", "POWELL", "POWHATAN POINT", "PROCTORVILLE", "PROSPECT", "PUT-IN-BAY", "QUAKER CITY", "QUINCY", "RACINE", "RARDEN", "RAVENNA", "RAWSON", "RAYLAND", "READING", "REMINDERVILLE", "RENDVILLE", "REPUBLIC", "REYNOLDSBURG", "RICHFIELD", "RICHMOND", "RICHMOND HEIGHTS", "RICHWOOD", "RIDGEWAY", "RIO GRANDE", "RIPLEY", "RISINGSUN", "RITTMAN", "RIVERLEA", "RIVERSIDE", "ROAMING SHORES", "ROCHESTER", "ROCK CREEK", "ROCKFORD", "ROCKY RIDGE", "ROCKY RIVER", "ROGERS", "ROME", "ROSEMOUNT", "ROSEVILLE", "ROSS", "ROSSBURG", "ROSSFORD", "ROSWELL", "RUSHSYLVANIA", "RUSHVILLE", "RUSSELLS POINT", "RUSSELLVILLE", "RUSSIA", "RUTLAND", "SABINA", "ST. BERNARD", "ST. CLAIRSVILLE", "ST. HENRY", "ST. LOUISVILLE", "ST. MARTIN", "ST. MARYS", "ST. PARIS", "SALEM", "SALESVILLE", "SALINEVILLE", "SANDUSKY", "SANDUSKY SOUTH", "SARAHSVILLE", "SARDINIA", "SAVANNAH", "SCIO", "SCIOTODALE", "SCOTT", "SEAMAN", "SEBRING", "SENECAVILLE", "SEVEN HILLS", "SEVEN MILE", "SEVILLE", "SHADYSIDE", "SHAKER HEIGHTS", "SHARONVILLE", "SHAWNEE", "SHAWNEE HILLS", "SHAWNEE HILLS", "SHEFFIELD", "SHEFFIELD LAKE", "SHELBY", "SHERRODSVILLE", "SHERWOOD", "SHERWOOD", "SHILOH", "SHILOH", "SHREVE", "SIDNEY", "SILVER LAKE", "SILVERTON", "SINKING SPRING", "SMITHFIELD", "SMITHVILLE", "SOLON", "SOMERSET", "SOMERVILLE", "SOUTH AMHERST", "SOUTH BLOOMFIELD", "SOUTH CANAL", "SOUTH CHARLESTON", "SOUTH EUCLID", "SOUTH LEBANON", "SOUTH MIDDLETOWN", "SOUTH POINT", "SOUTH RUSSELL", "SOUTH SALEM", "SOUTH SOLON", "SOUTH VIENNA", "SOUTH WEBSTER", "SOUTH ZANESVILLE", "SPARTA", "SPENCER", "SPENCERVILLE", "SPRINGBORO", "SPRINGDALE", "SPRINGFIELD", "SPRING VALLEY", "STAFFORD", "STEUBENVILLE", "STOCKPORT", "STONE CREEK", "STONY PRAIRIE", "STOUTSVILLE", "STOW", "STRASBURG", "STRATTON", "STREETSBORO", "STRONGSVILLE", "STRUTHERS", "STRYKER", "SUGAR BUSH KNOLLS", "SUGARCREEK", "SUGAR GROVE", "SUMMERFIELD", "SUMMERSIDE", "SUMMITVILLE", "SUNBURY", "SWANTON", "SYCAMORE", "SYLVANIA", "SYRACUSE", "TALLMADGE", "TARLTON", "TERRACE PARK", "THE PLAINS", "THE VILLAGE OF INDIAN HILL", "THORNVILLE", "THURSTON", "TIFFIN", "TILTONSVILLE", "TIMBERLAKE", "TIPP CITY", "TIRO", "TOLEDO", "TONTOGANY", "TORONTO", "TREMONT CITY", "TRENTON", "TRIMBLE", "TROTWOOD", "TROY", "TURPIN HILLS", "TUSCARAWAS", "TWINSBURG", "UHRICHSVILLE", "UNION", "UNION CITY", "UNIONTOWN", "UNIONVILLE CENTER", "UNIOPOLIS", "UNIVERSITY HEIGHTS", "UPPER ARLINGTON", "UPPER SANDUSKY", "URBANA", "URBANCREST", "UTICA", "VALLEY HI", "VALLEY VIEW", "VALLEYVIEW", "VAN BUREN", "VANDALIA", "VANLUE", "VAN WERT", "VENEDOCIA", "VERMILION", "VERONA", "VERSAILLES", "VIENNA CENTER", "VINTON", "WADSWORTH", "WAITE HILL", "WAKEMAN", "WALBRIDGE", "WALDO", "WALTON HILLS", "WAPAKONETA", "WARREN", "WARRENSVILLE HEIGHTS", "WARSAW", "WASHINGTON", "WASHINGTONVILLE", "WATERVILLE", "WAUSEON", "WAVERLY CITY", "WAYNE", "WAYNE LAKES", "WAYNESBURG", "WAYNESFIELD", "WAYNESVILLE", "WELLINGTON", "WELLSTON", "WELLSVILLE", "WEST ALEXANDRIA", "WEST CARROLLTON CITY", "WEST ELKTON", "WESTERVILLE", "WEST FARMINGTON", "WESTFIELD CENTER", "WEST HILL", "WEST JEFFERSON", "WEST LAFAYETTE", "WESTLAKE", "WEST LEIPSIC", "WEST LIBERTY", "WEST MANCHESTER", "WEST MANSFIELD", "WEST MILLGROVE", "WEST MILTON", "WESTON", "WEST PORTSMOUTH", "WEST RUSHVILLE", "WEST SALEM", "WEST UNION", "WEST UNITY", "WETHERINGTON", "WHARTON", "WHEELERSBURG", "WHITEHALL", "WHITEHOUSE", "WHITE OAK", "WHITE OAK EAST", "WHITE OAK WEST", "WICKLIFFE", "WILBERFORCE", "WILKESVILLE", "WILLARD", "WILLIAMSBURG", "WILLIAMSPORT", "WILLOUGHBY", "WILLOUGHBY HILLS", "WILLOWICK", "WILLSHIRE", "WILMINGTON", "WILMOT", "WILSON", "WINCHESTER", "WINDHAM", "WINTERSVILLE", "WITHAMSVILLE", "WOODBOURNE-HYDE PARK", "WOODLAWN", "WOODMERE", "WOODSFIELD", "WOODSTOCK", "WOODVILLE", "WOOSTER", "WORTHINGTON", "WREN", "WRIGHT-PATTERSON AFB", "WYOMING", "XENIA", "YANKEE LAKE", "YELLOW SPRINGS", "YORKSHIRE", "YORKVILLE", "YOUNGSTOWN", "ZALESKI", "ZANESFIELD", "ZANESVILLE", "ZOAR" };
            string[] cityArray = { "ABERDEEN", "ADA", "ADAMSVILLE", "ADDYSTON", "ADELPHI", "ADENA", "AKRON", "ALBANY", "ALEXANDRIA", "ALGER", "ALLIANCE", "ALVORDTON", "AMANDA", "AMBERLEY"};
            int count = cityArray.Count();
            string state = "OH";
            //string path = @"http://api.wunderground.com/api/" + wunderground_key + "/conditions/q/";
            for (int i = 0; i <= count; i++)
            {
                try
                {
                     abc = "http://api.wunderground.com/api/" + wunderground_key + "/conditions/q/" + state + "/" + cityArray[i] + ".xml";// parse("http://api.wunderground.com/api/" + wunderground_key + "/conditions/q/" + state + "/" + cityArray[i] + "/.xml");
                }
                catch { }
                    //parse(abc);
                //Variables
                string place = "";
                string obs_time = "";
                string weather1 = "";
                string temperature_string = "";
                string relative_humidity = "";
                string wind_string = "";
                string pressure_mb = "";
                string dewpoint_string = "";
                string visibility_km = "";
                string latitude = "";
                string longitude = "";

                var cli = new WebClient();
                string weather = cli.DownloadString(abc);

                
                using (XmlReader reader = XmlReader.Create(new StringReader(weather)))
                {
                    // Parse the file and display each of the nodes.
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (reader.Name.Equals("full"))
                                {
                                    reader.Read();
                                    place = reader.Value;
                                }
                                else if (reader.Name.Equals("observation_time"))
                                {
                                    reader.Read();
                                    obs_time = reader.Value;
                                }
                                else if (reader.Name.Equals("weather"))
                                {
                                    reader.Read();
                                    weather1 = reader.Value;
                                }
                                else if (reader.Name.Equals("temperature_string"))
                                {
                                    reader.Read();
                                    temperature_string = reader.Value;
                                    string[] abcx = temperature_string.Split('F');//, StringSplitOptions.RemoveEmptyEntries);
                                    string tem = abcx[0];
                                    if (Convert.ToDecimal(tem) > 70)
                                    {
                                        temperatHigh[tempHi] = tem;
                                        Console.WriteLine("temperatHigh");
                                        Console.WriteLine(tem);
                                        tempHi++;
                                    }
                                    else
                                    {
                                        temperatLow[tempLow] = tem;
                                        Console.WriteLine("temperat low");
                                        Console.WriteLine(tem);
                                        tempLow++;
                                    }
                                }
                                else if (reader.Name.Equals("relative_humidity"))
                                {
                                    reader.Read();
                                    relative_humidity = reader.Value;
                                }
                                else if (reader.Name.Equals("wind_string"))
                                {
                                    reader.Read();
                                    wind_string = reader.Value;
                                }
                                else if (reader.Name.Equals("pressure_mb"))
                                {
                                    reader.Read();
                                    pressure_mb = reader.Value;
                                }
                                else if (reader.Name.Equals("dewpoint_string"))
                                {
                                    reader.Read();
                                    dewpoint_string = reader.Value;
                                }
                                else if (reader.Name.Equals("visibility_km"))
                                {
                                    reader.Read();
                                    visibility_km = reader.Value;
                                }
                                else if (reader.Name.Equals("latitude"))
                                {
                                    reader.Read();
                                    latitude = reader.Value;
                                    Console.WriteLine(latitude);
                                }
                                else if (reader.Name.Equals("longitude"))
                                {
                                    reader.Read();
                                    longitude = reader.Value;
                                    Console.WriteLine(longitude);
                                }

                                break;
                        }
                    }
                }
            }

            Console.WriteLine("////////////////////////");
            Console.WriteLine("temperatHigh");
            foreach (string i in temperatHigh)
                Console.WriteLine(i);

            Console.WriteLine("temperat low");
            foreach (string i in temperatLow)
                Console.WriteLine(i);
            //parse("http://api.wunderground.com/api/" + wunderground_key + "/conditions/q/" + state + "/cleveland.xml");
            //parse("http://api.wunderground.com/api/" + wunderground_key + "/conditions/q/" + state + "/akron.xml");
            //parse("http://api.wunderground.com/api/" + wunderground_key + "/conditions/q/" + state + "/solon.xml");
            //parse("http://api.wunderground.com/api/" + wunderground_key + "/conditions/q/" + state + "/hudson.xml");
            //Console.WriteLine("enter API key");
            Console.ReadKey();
        }
        
    }
}
