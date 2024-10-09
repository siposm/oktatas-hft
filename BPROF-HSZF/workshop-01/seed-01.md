```csharp
List<Employee> employees = new List<Employee>()
{
    new Employee("Ambrus Csaba","ambrus.csaba@nik.uni-obuda.hu","Dékáni Hivatal","műszaki ügyintéző","+36 (1) 666-5510","BA.2.11"),
    new Employee("B. Kiss Judit","bkiss.judit@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","igazgatási ügyintéző","+36 (1) 666-5550","BA.3.13"),
    new Employee("Balázs Éva","balazs.eva@nik.uni-obuda.hu","Dékáni Hivatal","igazgatási ügyintéző","+36 (1) 666-5520","BA.4.06"),
    new Employee("Balázs Éva","titkarsag@nik.uni-obuda.hu","Dékáni Hivatal","NIK titkárság központi címe","+36 (1) 666-5520","BA.4.06"),
    new Employee("Bedők Dávid","bedok.david@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","ügyvivő szakértő","+36 (1) 666-5582","BA.3.02"),
    new Employee("Bringye Zsolt","bringye.zsolt@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","ügyvivő szakértő","+36 (1) 666-5574","TA.3.06"),
    new Employee("Bácskai Zsuzsanna","bacskai.zsuzsanna@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","igazgatási ügyintéző","+36 (1) 666-5541","BA.4.08"),
    new Employee("Vörösné Bánáti-Baumann Anna","banati.anna@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanársegéd","+36 (1) 666-5574","BA.3.06"),
    new Employee("Cserfalvi Annamária","cserfalvi.annamaria@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5590","BA.2.16"),
    new Employee("Cseri Orsolya Eszter","cseri.eszter@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5582","TA.3.02"),
    new Employee("Dr. Cserjés Ágota","cserjes.agota@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","címzetes egyetemi docens, óraadó","+36 (1) 666-5595","TA.4.11"),
    new Employee("Csicsek Judit","csicsek.judit@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","mestertanár","+36 (1) 666-5597","TA.4.15"),
    new Employee("Dr. Csink László","csink.laszlo@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","egyetemi docens, főiskolai tanár","+36 (1) 666-5581","BA.3.03"),
    new Employee("Dr. Csiszár Orsolya","csiszar.orsolya@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","adjunktus","+36 (1) 666-5595","BA.4.11"),
    new Employee("Dr. habil. Kovács Levente","kovacs.levente@nik.uni-obuda.hu","Biomatika Intézet","egyetemi tanár, oktatási dékánhelyettes, szakterület felelős,H2020 ERC grant projekt koordinátor, igazgató,H2020 ERC StG grant Principal Investigator","+36 (1) 666-5585","BA.4.06"),
    new Employee("Drexler Dániel","drexler.daniel@nik.uni-obuda.hu","Biomatika Intézet","adjunktus","+36 (1) 666-5553","BA.3.25"),
    new Employee("Dóczi Roland","doczi.roland@nik.uni-obuda.hu","Biomatika Intézet","demonstrátor","+36 (1) 666-5535","KC.3.04"),
    new Employee("Ecsedi Csaba","ecsedi.csaba@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","felkészítő tanár","+36 (1) 666-5534","BA.1.12"),
    new Employee("Dr. Erdélyi Krisztina","erdelyi.krisztina@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","adjunktus","+36 (1) 666-5575","BA.3.09"),
    new Employee("Dr. Erdődi László","erdodi.laszlo@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","adjunktus, Etikus Hacker Labor vezető","+36 (1) 666-5575","BA.3.09"),
    new Employee("Dr. Farkas Károly CSc.","farkas.karoly@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","főiskolai docens, óraadó","+36 (1) 666-5514","BA.3.16"),
    new Employee("Dr. Fehér Gyula","feher.gyula@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","címzetes egyetemi docens, óraadó","+36 (1) 666-5589","BA.2.16"),
    new Employee("Dr. Fleiner Rita","fleiner.rita@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","adjunktus, szakterület felelős","+36 (1) 666-5578","BA.3.18"),
    new Employee("Prof. Dr. Fullér Róbert","fuller.robert@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","egyetemi tanár, intézetigazgató","+36 (1) 666-5537","BA.4.17"),
    new Employee("Dr. Fülöp János","fulop.janos@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","egyetemi "),
    new Employee("Prof. Dr. Galántai Aurél","galantai.aurel@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","egyetemi tanár, Alkalmazott Informatikai és Alkalmazott Matematikai Doktori iskola tanácsának elnöke, Doktori Iskola vezetője","+36 (1) 666-5616","BA.4.23"),
    new Employee("Garaguly Zoltán","garaguly.zoltan@nik.uni-obuda.hu","Biomatika Intézet","tanszéki mérnök","+36 (20) 536-0416","KC.3.03"),
    new Employee("Gulácsi Gábor","gulacsi.gabor@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","demons"),
    new Employee("Dr. György Anna","gyorgy.anna@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","főiskolai docens","+36 (1) 666-5525","BA.4.14"),
    new Employee("Győriné Kontor Éva","gyorine.eva@rh.uni-obuda.hu","Dékáni Hivatal","nyelvtanár","+36 (1) 666-5704","KC.1.08"),
    new Employee("Dr. Hegedüs Gábor","hegedus.gabor@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","egyetemi docens","+36 1 666-5729","KC.1.11"),
    new Employee("Dr. Holyinka Péter","holyinka.peter@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","címzetes egyetemi docens, óraadó","+36 (1) 666-5556","BA.3.17"),
    new Employee("Jónás Gábor","jonas.gabor@nik.uni-obuda.hu","Neumann János Informatikai Kar","műszaki ügyintéző","+36 (1) 666-5510","BA.2.11"),
    new Employee("Balázsné Kail Eszter","kail.eszter@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanársegéd","+36 (1) 666-5574","BA.3.06"),
    new Employee("Kelemen József","kelemen.jozsef@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5587","BA.3.22"),
    new Employee("Kertész Gábor","kertesz.gabor@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5568","BA.3.08"),
    new Employee("Kiss Dániel","kiss.daniel@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5568","BA.3.08"),
    new Employee("Kiss Mária","kiss.maria@nik.uni-obuda.hu","Dékáni Hivatal","gazdasági csoportvezető","+36 (1) 666-5570","BA.4.03"),
    new Employee("Klespitzné Kovács Krisztina Rita","kovacs.krisztina@nik.uni-obuda.hu","Neumann János Informatikai Kar","igazgatási ügyintéző","+36 (1) 666-5773","BA.3.27"),
    new Employee("Koschek Vilmos","koschek.vilmos@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","óraadó","BA.3.13"),
    new Employee("Kovács András","kovacs.andras@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","műszaki ügyintéző","+36 (1) 666-5568","BA.3.08"),
    new Employee("Dr. Kutor László","kutor.laszlo@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","egyetemi docens, főiskolai tanár","+36 (1) 666-5588","BA.1.18"),
    new Employee("Dr. Kárász Péter","karasz.peter@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","egyetemi docens, intézetigazgató-helyettes, BSc koordinátor","+36 (1) 666-5596","BA.4.12"),
    new Employee("Kőhalmi Vivien","kohalmi.vivien@nik.uni-obuda.hu","Dékáni Hivatal","igazgatási ügyintéző","+36 (1) 666-5544","BA.4.22"),
    new Employee("Lovas István","lovas.istvan@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5586","BA.3.22"),
    new Employee("Léczfalvy Ádám","leczfalvy.adam@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5586","BA.3.22"),
    new Employee("Légrádi Gábor","legradi.gabor@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","mestertanár","+36 (1) 666-5577","BA.3.07"),
    new Employee("Maróthy Zita","marothy.zita@nik.uni-obuda.hu","Tanulmányi Osztály","igazgatási ügyintéző","+36 (1) 666-5561","BA.1.17"),
    new Employee("Mezei József","mezei.jozsef@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5576","BA.3.22"),
    new Employee("Mihályi Martin","mihalyi.martin@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","óraadó","+36 (1) 666-5575","BA.3.09"),
    new Employee("Nagy András","nagy.andras@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5514","BA.3.16"),
    new Employee("Nagy István","nagy.istvan@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","mestertanár"),
    new Employee("Prof. Dr. Nagy Péter Tibor","nagy.peter@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","egyetemi tanár","+36 (1) 666-5512","BA.4.20"),
    new Employee("Nagy Tibor István","nagy.tibor@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanársegéd","+36 (1) 666-5581","BA.3.03"),
    new Employee("Nógrády Vajk","nogrady.vajk@nik.uni-obuda.hu","Tanulmányi Osztály","igazgatási ügyintéző","+36 (1) 666-5565","BA.1.17"),
    new Employee("Pethes Róbert","pethes.robert@phd.uni-obuda.hu","Alkalmazott Informatikai és Alkalmazott Matematikai Doktori Iskola","PhD ha"),
    new Employee("Pick András","pick.andras@nik.uni-obuda.hu","Tanulmányi osztály","Tanulmányi ügyintéző","+36 (1) 666-5563","BA.1.17"),
    new Employee("Pintér Gergő","pinter.gergo@nik.uni-obuda.hu","Alkalmazott Informatikai és Alkalmazott Matematikai Doktori Iskola","PhD ha"),
    new Employee("Pintér Ádám","pinter.adam@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5575","BA.3.09"),
    new Employee("Piros Péter","piros.peter@nik.uni-obuda.hu","Alkalmazott Informatikai és Alkalmazott Matematikai Doktori Iskola","doktorandusz","+36 (1) 666-5514","BA.3.16"),
    new Employee("Prof. Dr. Pap Endre","pap.endre@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","kutatóprofesszor","+36 (1) 666-5537","BA.4.17"),
    new Employee("Prém Dániel","prem.daniel@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5580","BA.3.04"),
    new Employee("Dr. Rövid András","rovid.andras@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet", "óraadó"),
    new Employee("Dr. Sergyán Szabolcs","sergyan.szabolcs@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","egyetemi docens, intézetigazgató, kari Erasmus koordinátor","+36 (1) 666-5550","BA.3.13"),
    new Employee("Sicz-Mesziár János","sicz-mesziar.janos@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","műszaki ügyintéző","+36 (1) 666-5587","BA.3.22"),
    new Employee("Simon Ádám","simon.adam@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5580","BA.3.04"),
    new Employee("Simon-Nagy Gabriella","nagy.gabriella@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanársegéd","+36 (1) 666-5578","BA.3.18"),
    new Employee("Sipos Miklós","sipos.miklos@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5568","BA.3.08"),
    new Employee("Somlyai László","somlyai.laszlo@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanársegéd","+36 (1) 666-5549","BA.3.23"),
    new Employee("Dr. Stojcsics Dániel","stojcsics.daniel@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","adjunktus, szakterület felelős","+36 (1) 666-5586","BA.3.22"),
    new Employee("Susik Márta","susik.marta@nik.uni-obuda.hu","Oktatási Csoport","igazgatási ügyintéző","+36 (1) 666-5527","BA.4.10"),
    new Employee("Dr. Szabó Gábor","szabo.gabor@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","egyetemi tanár"),
    new Employee("Szabó-Resch Miklós Zsolt","szabo.zsolt@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","ügyvivő szakértő","+36 (1) 666-5582","BA.3.02"),
    new Employee("Szabó-Zsidai Krisztina","szabo-zsidai.krisztina@rkk.uni-obuda.hu","Tanulmányi Osztály","igazgatási ügyintéző","+36 (1) 666-5912","BA.4.44"),
    new Employee("Prof. Dr. Szeidl László","szeidl@uni-obuda.hu","Alkalmazott Informatikai Intézet","egyetemi tanár","+36 (1) 666-5920","BA.4.21"),
    new Employee("Dr. Szenes Katalin","szenes.katalin@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","címzetes egyetemi docens, óraadó","+36 (1) 666-5556","BA.3.17"),
    new Employee("Sziklai Zsolt","sziklai.zsolt@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5587","BA.3.22"),
    new Employee("Dr. Szénási Sándor","szenasi.sandor@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","egyetemi docens, szakterület felelős, CUDA Teaching Center vezető","+36 (1) 666-5532","BA.3.11"),
    new Employee("Dr. Szőke Magdolna","szoke.magdolna@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","adjunktus","+36 (1) 666-5536","BA.4.13"),
    new Employee("Sántáné-Tóth Edit","santane.edit@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","címzetes egyetemi docens, óraadó","+36 (1) 666-5514","BA.3.16"),
    new Employee("Dr. Takács Márta","takacs.marta@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","egyetemi docens","+36 (1) 666-5546","BA.4.19"),
    new Employee("Tanos Katalin","tanos.katalin@nik.uni-obuda.hu","Tanulmányi Osztály","igazgatási ügyintéző","+36 (1) 666-5511","BA.1.17"),
    new Employee("Dr. Tick József","tick@uni-obuda.hu","Rektori Hivatal","innovációs főigazgató, egyetemi docens","+36 (1) 666-5668","BA.1.06"),
    new Employee("Tikász Ádám","tikasz.adam@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5580","BA.3.04"),
    new Employee("Tiszai Tamás","tiszai.tamas@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","mestertanár","+36 (1) 666-5574","BA.3.06"),
    new Employee("Tóth András","toth.andras@nik.uni-obuda.hu","Dékáni Hivatal","műszaki ügyintéző, csoportvezető","+36 (1) 666-5567","BA.3.15"),
    new Employee("Tóth Ádám","toth.adam@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","demonstrátor","+36 (1) 666-5525","BA.4.14"),
    new Employee("Dr. Vajda István","vajda.istvan@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","adjunktus","+36 (1) 666-5597","BA.4.15"),
    new Employee("Varga Viktor","varga.viktor@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet"),
    new Employee("Vladárné Kiss Andrea","kiss.andrea@nik.uni-obuda.hu","Oktatási Csoport","igazgatási ügyintéző","+36 (1) 666-5526","BA.4.10"),
    new Employee("Dr. Vámossy Zoltán","vamossy.zoltan@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","egyetemi docens, intézetigazgató-helyettes, TDK-felelős","+36 (1) 666-5550","BA.3.12"),
    new Employee("Vígh Tamás","vigh.tamas@nik.uni-obuda.hu","Alkalmazott Informatikai Intézet","tanszéki mérnök","+36 (1) 666-5589","BA.2.16"),
    new Employee("Zsíros Tímea","zsiros.timea@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","tanársegéd","+36 (1) 666-5536","BA.4.13"),
    new Employee("Záborszky Ágnes","zaborszky.agnes@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","mestertanár","+36 (1) 666-5596","BA.4.12"),
    new Employee("Tony Stark","tony.stark@nik.uni-obuda.hu","Alkalmazott Matematikai Intézet","polihisztor","+36 (1) 666-1111","BA.0.00"),
    new Employee("Bruce Banner","bruce.banner@gmail.com","Alkalmazott Matematikai Intézet","polihisztor","+36 (1) 666-1111","BA.0.00")
};

Console.WriteLine("\n================================================");
Console.WriteLine("AKIK NEVE 'T' BETŰVEL KEZDŐDIK AZOKAT LISTÁZZUK KI.\n");
Console.WriteLine("\n================================================");
Console.WriteLine("AKIK POLIHISZTORKÉNT DOLGOZNAK AZOKAT KÉRDEZZÜK LE.\n");
Console.WriteLine("\n================================================");
Console.WriteLine("SZŰRJÜK KI (NÉV+EMAIL) AZOKAT AKIK GMAIL-ES CÍMMEL RENDELKEZNEK.\n");
Console.WriteLine("\n================================================");
Console.WriteLine("AZ AII-BEN DOLGOZÓK NEVEIT LISTÁZZUK KI ABC CSÖKKENŐBEN.\n");
Console.WriteLine("\n================================================");
Console.WriteLine("HÁNYAN VANNAK AZ EGYES INTÉZETEKBEN?\n");
Console.WriteLine("\n================================================");
Console.WriteLine("HÁNYAN VANNAK AZ EGYES SZOBÁKBAN?\n");
Console.WriteLine("\n================================================");
Console.WriteLine("A 3. LEGKISEBB INTÉZETBEN HÁNYAN DOLGOZNAK?\n");
Console.WriteLine("\n================================================");
Console.WriteLine("AZ AII-BEN DOLGOZÓKAT MÓDOSÍTSUK ÉS ADJUNK NEKIK FIZETÉST.\n");
Console.WriteLine("\n================================================");
Console.WriteLine("MENNYI AZ AII-BEN AZ ÁTLAGKERESET?\n");
Console.WriteLine("\n================================================");
Console.WriteLine("A TELJES ÉS FÉLÁLLÁSÚAK HÁNYAN VANNAK ÉS MENNYI AZ ÁTLAG/MAX/MIN KERESET?\n");
Console.WriteLine("\n================================================");
Console.WriteLine("KIK KERESNEK TÖBBET MINT AZ AII TAGOK ÁTLAGÁNÁL?\n");
Console.WriteLine("\n================================================");
Console.WriteLine("KIK DOLGOZNAK A 3. EMELETEN?\n");
Console.WriteLine("\n================================================");
Console.WriteLine("KIK AZOK AKIKNEK TÖBB FELADATKÖRE IS VAN?\n");

```