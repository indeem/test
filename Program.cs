using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FahrzeugProgramm
{
    public class Programm
    {
        //Deklaration und Initalisierung verschiederner Variablen für die gesamte Klasse FahrzeugeProgramm
        static string jsonPfadSpeicher = @"N:\Ausbildung\Yannik Köllmann\Fahrzeug Pfadspeicher\Pfad.txt";
        static string jsonPfad;
        static int listeÜbernehmen = 0;
        static List<List<string>> alleFahrzeuge = new List<List<string>>();

        public class FahrzeugeProgramm
        {
            
            class Menü
            {
                //Deklaration und teilweise Initialisierung verschiedener Variablen für die gesamte Klasse Menü
                static int Menüs;
                static int eingabeZurück;
                static string eingabeName;
                static string fahrzeugEingabeName;
                static string programmStopp = "Weiter";
                static int menüAuswahlEingabe;
                static int Auswahl = 0;


                static void Main(string[] args)
                {
                    jsonPfadSpeicherInitialisierung();
                    //aufrufen der Methode jsonPfadInitialisierung
                    jsonPfadInitialisierung();
                    //aufrufen der Methode jsonPfadEingabe
                    jsonPfadEingabeAuswahl();
                    //aufrufen einer while-Schleife
                    while (programmStopp != "Stopp")
                    {
                        //Aufrufen der Methode übernahmeListe
                        übernahmeListe();
                        
                        //damit bei jedem Ablauf des Programms der Schritt des auslesens nicht wiederholt wird, erhöhen der Variable um 1
                        listeÜbernehmen++;
                        Console.Clear();
                        //Aufrufen der Methode MenüAusgabe
                        MenüAusgabe();
                        //Deklarieren der Variable menüAuswahlEingabe mithilfe der Methode MenüAuswahl
                        menüAuswahlEingabe = MenüAuswahl();
                        //aufrufen einer switch-case-Funktion
                        switch (menüAuswahlEingabe)
                        {
                            case 1:
                                //Aufrufen der Methode FahrzeugMenü und anschließend erneute deklaration der Variable menüAuswahlEingabe
                                Console.Clear();
                                FahrzeugMenü();
                                menüAuswahlEingabe = FahrzeugMenüAuswahl();
                                //aufrufen einer weiteren switch-case-Funktion
                                switch (menüAuswahlEingabe)
                                {
                                    case 1:
                                        //Aufrufen der Methode fahrzeugAusgabe und anschließend deklaration der Variable menüAuswahlEingabe
                                        Console.Clear();
                                        fahrzeugAusgabe();
                                        menüAuswahlEingabe = fahrzeugAuswahl();
                                        //Aufrufen einer weiteren switch-case-Funktion in welcher für die verschiedenen Fahrzeugmöglichkeiten die Namen dieser
                                        //deklariert werden, und im Anschluss Aufrufen zweier Methoden zum deklarieren des Fahrzeugs als Objekt im Programm und 
                                        //in der Json-Datei
                                        switch (menüAuswahlEingabe)
                                        {
                                            case 1:
                                                fahrzeugEingabeName = "Auto";
                                                eingabeBeliebig();
                                                auswahlMenü();
                                                break;
                                            case 2:
                                                fahrzeugEingabeName = "E-Auto";
                                                eingabeBeliebig();
                                                auswahlMenü();
                                                break;
                                            case 3:
                                                fahrzeugEingabeName = "LKW";
                                                eingabeBeliebig();
                                                auswahlMenü();
                                                break;
                                            case 4:
                                                fahrzeugEingabeName = "Fahrrad";
                                                eingabeBeliebig();
                                                auswahlMenü();
                                                break;
                                            case 5:
                                                fahrzeugEingabeName = "Skateboard";
                                                eingabeBeliebig();
                                                auswahlMenü();
                                                break;
                                            case 6:
                                                fahrzeugEingabeName = "Flugzeug";
                                                eingabeBeliebig();
                                                auswahlMenü();
                                                break;
                                            case 7:
                                                eingabeBeliebig();
                                                auswahlMenü();
                                                break;
                                            case -1:
                                                break;


                                        }
                                        break;
                                    //Aufrufen der Methoden StatüsMenü und StatusAuswahl
                                    case 2:
                                        Console.Clear();
                                        StatusMenü();
                                        StatusAuswahl();
                                        break;
                                }
                                break;
                            //Aufrufen der Methoden StatusÜbersichtMenü und auswahlMenü
                            case 2:
                                StatusÜbersichtMenü();
                                StatusNamenAuswahl();
                                auswahlMenü();
                                break;
                            //Aufrufen der Methoden AusgabeAllerFahrzeuge und auswahlMenü
                            case 3:
                                AusgabeAllerFahrzeuge();
                                auswahlMenü();
                                break;
                        }

                    }
                }


                static void jsonPfadSpeicherInitialisierung()
                {
                    if (!File.Exists(@"N:\Ausbildung\Yannik Köllmann\Fahrzeug Pfadspeicher\Pfad.txt"))
                    {
                        Console.WriteLine("Eingabe Speicherpfad");
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine("\nGeben Sie den Pfad ein, wo der Pfadspeicher gespeichert werden soll.");
                        Console.WriteLine("Die Eingabe sollte in Folgendem Format erfolgen:");
                        Console.WriteLine("N:\\Ausbildung\\Yannik Köllmann\\Fahrzeugprogramm Json");
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.Write("\nIhre Eingabe: ");
                        //Deklaration der Variablen jsonPfad
                        jsonPfadSpeicher = Console.ReadLine();
                        //Entfernen des letzten Zeichens von dem String jsonPfad
                        jsonPfadSpeicher.Substring(0, jsonPfadSpeicher.Length - 1);
                        //initialisieren der Variablen jsonPfad um damit weiter arbeiten zu können
                        jsonPfadSpeicher = @$"{jsonPfadSpeicher}\Pfad.txt";
                        //Deklarieren und Initialisieren der Variablen json
                        string json;
                        json = jsonPfadSpeicher;
                        //Ersetzen des bestehenden Pfades mit neuem json String
                        File.WriteAllText(jsonPfadSpeicher, jsonPfadSpeicher);
                        jsonPfadEingabe();
                    }
                }



                static void jsonPfadInitialisierung()
                {
                    //Auslesen einer Textdatei
                    jsonPfad = File.ReadAllText(jsonPfadSpeicher);
                }


                static void jsonPfadEingabeAuswahl()
                {
                    Console.Clear();
                    //Ausgaben in der Konsole
                    Console.WriteLine("Pfadauswahl");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.WriteLine("\nWollen Sie einen neuen Pfad festlegen oder mit dem letzten Pfad fortfahren?");
                    Console.WriteLine($"Der Standardpfad lautet: {jsonPfad}");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.WriteLine("\nGeben Sie \"ja\" ein wenn Sie fortfahren wollen.");
                    Console.WriteLine("\nGeben Sie \"nein\" ein wenn Sie einen neuen Pfad eingeben wollen.");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.Write("\nIhre Eingabe: ");
                    //Deklarieren und Initialisieren der Variablen eingabe
                    string eingabe = Console.ReadLine();
                    //Prüfen was für eingabe eingegeben wurde
                    switch (eingabe)
                    {
                        case "ja":
                            break;
                        case "nein":
                            jsonPfadEingabe();
                            break;
                        default:
                            //Ausgaben in der Konsole
                            Console.WriteLine("________________________________________________________________________________________________________________________");
                            Console.WriteLine("\nSie müssen ja oder nein eingeben.");
                            Console.WriteLine("Geben Sie Enter ein um es nochmal zu probieren");
                            Console.ReadLine();
                            Console.Clear();
                            //Aufrufen einer while-Schleife
                            while (eingabe != "ja" && eingabe != "nein")
                            {
                                //das gleiche wie vorher
                                Console.WriteLine("Pfadauswahl");
                                Console.WriteLine("________________________________________________________________________________________________________________________");
                                Console.WriteLine("\nWollen Sie einen neuen Pfad festlegen oder mit dem Standardpfad fortfahren?");
                                Console.WriteLine($"Der Standardpfad lautet: {jsonPfad}");
                                Console.WriteLine("________________________________________________________________________________________________________________________");
                                Console.WriteLine("\nGeben Sie \"ja\" ein wenn Sie fortfahren wollen.");
                                Console.WriteLine("\nGeben Sie \"nein\" ein wenn Sie einen neuen Pfad eingeben wollen.");
                                Console.WriteLine("________________________________________________________________________________________________________________________");
                                Console.Write("\nIhre Eingabe: ");
                                eingabe = Console.ReadLine();
                                switch (eingabe)
                                {
                                    case "ja":
                                        break;
                                    case "nein":
                                        jsonPfadEingabe();
                                        break;
                                    default:
                                        Console.WriteLine("________________________________________________________________________________________________________________________");
                                        Console.WriteLine("\nSie müssen ja oder nein eingeben.");
                                        Console.WriteLine("Geben Sie Enter ein um es nochmal zu probieren sss");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                }
                            }
                            break;
                    }
                }


                static void jsonPfadEingabe()
                {
                    Console.Clear();
                    //Ausgaben in der Konsole
                    Console.WriteLine("Eingabe Speicherpfad");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.WriteLine("\nGeben Sie den Pfad ein, wo die Textdatei gespeichert werden soll.");
                    Console.WriteLine("Die Eingabe sollte in Folgendem Format erfolgen:");
                    Console.WriteLine("N:\\Ausbildung\\Yannik Köllmann\\Fahrzeugprogramm Json");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.Write("\nIhre Eingabe: ");
                    //Deklaration der Variablen jsonPfad
                    jsonPfad = Console.ReadLine();
                    //prüfen, ob der Eingegebene Pfad existiert
                    if (!Directory.Exists(jsonPfad))
                    {
                        //Ausgaben in der Konsole
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine("\nFehler, dieser Pfad existiert nicht.");
                        Console.WriteLine("\nDrücken Sie Enter um es nochmal zu probieren.");
                        Console.ReadLine();
                        //Deklaration und Initalisierung der Variablen erfolg
                        bool erfolg = false;
                        //Aufrufen einer while-Schleife
                        while (erfolg == false)
                        {
                            //Ausgaben in der Konsole
                            Console.Clear();
                            Console.WriteLine("Eingabe Speicherpfad");
                            Console.WriteLine("________________________________________________________________________________________________________________________");
                            Console.WriteLine("\nGeben Sie den Pfad ein, wo die Textdatei gespeichert werden soll.");
                            Console.WriteLine("Die Eingabe sollte in Folgendem Format erfolgen:");
                            Console.WriteLine("N:\\Ausbildung\\Yannik Köllmann\\Fahrzeugprogramm Json");
                            Console.WriteLine("________________________________________________________________________________________________________________________");
                            Console.Write("\nIhre Eingabe: ");
                            //Initialisieren der Variablen jsonPfad
                            jsonPfad = Console.ReadLine();
                            //Erneutes überprüfen, ob der eingegebene Pfad existiert
                            if (!Directory.Exists(jsonPfad))
                            {
                                //initialisieren der Variablen erfolg
                                erfolg = false;
                            }
                            else
                            {
                                //initialisieren der Variablen erfolg
                                erfolg = true;
                            }

                        }
                    }
                    else
                    {
                        
                    }
                    //Entfernen des letzten Zeichens von dem String jsonPfad
                    jsonPfad.Substring(0, jsonPfad.Length - 1);
                    //initialisieren der Variablen jsonPfad um damit weiter arbeiten zu können
                    jsonPfad = @$"{jsonPfad}\Fahrzeuge.txt";
                    //Deklarieren und Initialisieren der Variablen json
                    string json;
                    json = jsonPfad;
                    //Ersetzen des bestehenden Pfades mit neuem json String
                    File.WriteAllText(jsonPfadSpeicher, json);
                }

                static void übernahmeListe()
                {
                    //prüfen ob der vorher deklarierte und initialiserte Pfad existiert und falls Daten vorhanden sind, auslesen dieser und
                    //hinzufügen zur Liste aller Fahrzeuge
                    if (listeÜbernehmen == 0)
                    {
                        if (File.Exists(jsonPfad))
                        {
                            string json;
                            json = File.ReadAllText(jsonPfad);
                            List<List<string>> fahrzeugeGeladen = new List<List<string>>();
                            fahrzeugeGeladen = JsonConvert.DeserializeObject<List<List<string>>>(json);
                            for (int x = 0; x < fahrzeugeGeladen.Count; x++)
                            {
                                alleFahrzeuge.Add(fahrzeugeGeladen[x]);
                            }
                        }
                    }
                }
                static void MenüAusgabe()
                {
                    //Ausgaben in der Konsole
                    Console.WriteLine("Willkommen im Menü");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.WriteLine();
                    Console.WriteLine("1. Eingabe eines neuen Fahrzeuges / eines neuen Fahrzeugstatus");
                    Console.WriteLine("2. Statusabfrage");
                    Console.WriteLine("3. Ausgabe aller Fahrzeuge");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    //initialisieren der Variablen Menüs
                    Menüs = 1;
                }

                static int MenüAuswahl()
                {
                    //Ausgaben in der Konsole
                    Console.WriteLine("\nWelchen Punkt wollen Sie öffnen? Geben Sie die jeweilige Zahl ein.");
                    Console.WriteLine();
                    Console.WriteLine("Geben Sie \"Stopp\" ein, wenn Sie das Programm beenden wollen.");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.WriteLine();
                    Console.Write("Ihre Eingabe: ");
                    //Deklaration und Initialisierung der Variablen eingabeAuswahl mit der Methode prüfenAufGanzzahl
                    int eingabeAuswahl;
                    eingabeAuswahl = prüfenAufGanzzahl();
                    Console.WriteLine();
                    //Rückgabe des Wertes eingabeAuswahl
                    return eingabeAuswahl;
                }

                static void auswahlMenü()
                {
                    //prüfen ob variableZurück = -1 ist
                    if (eingabeZurück == -1)
                    {

                    }
                    else
                    {
                        //Ausgaben in der Konsole
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine();
                        Console.WriteLine("Wollen Sie zurück ins Menü oder soll das Programm geschlossen werden?");
                        Console.WriteLine("Geben Sie \"weiter\" ein, wenn das Menü aufgerufen werden soll.");
                        Console.WriteLine("Geben Sie \"Stopp\" ein wenn das Programm geschlossen werden soll.");
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine();
                        Console.Write("Ihre Eingabe: ");
                        //Aufrufen der Methode prüfenAufGanzzahl
                        prüfenAufGanzzahl();
                    }                    
                }
                static void FahrzeugMenü()
                {
                    //Ausgaben in der Konsole
                    Console.WriteLine("Fahrzeugmenü");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.WriteLine();
                    Console.WriteLine("1. Eintrag eines neuen Fahrzeuges");
                    Console.WriteLine("2. Eintrag eines neuen Status");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    //initialiseren der Variablen Menüs
                    Menüs = 2;

                }

                static int FahrzeugMenüAuswahl()
                {
                    //Ausgaben in der Konsole
                    Console.WriteLine("\nWelchen Punkt wollen Sie öffnen? Geben Sie die jeweilige Zahl ein.");
                    Console.WriteLine();
                    Console.WriteLine("Geben Sie \"zurück\" ein, wenn Sie zurück in das Hauptmenü wollen.");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.WriteLine();
                    Console.Write("Ihre Eingabe: ");
                    //Deklarieren und Initialisieren der Variablen eingabeAuswahl
                    int eingabeAuswahl;
                    eingabeAuswahl = prüfenAufGanzzahl();
                    Console.WriteLine();
                    //Rückgabe der Variablen eingabeAuswahl
                    return eingabeAuswahl;
                }

                static void fahrzeugAusgabe()
                {
                    //Ausgaben in der Konsole
                    Console.WriteLine("Fahrzeugauswahl");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.WriteLine();
                    Console.WriteLine("1. Auto");
                    Console.WriteLine("2. Elektroauto");
                    Console.WriteLine("3. LKW");
                    Console.WriteLine("4. Fahrrad");
                    Console.WriteLine("5. Skateboard");
                    Console.WriteLine("6. Flugzeug");
                    Console.WriteLine("7. beliebiges Fahrzeug");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    //initialisieren der Variablen Menüs
                    Menüs = 3;
                }

                static int fahrzeugAuswahl()
                {
                    //intiialisieren der Variablen Auswahl
                    Auswahl = 5;
                    //Ausgaben in der Konsole
                    Console.WriteLine("\nWelchen Punkt wollen Sie öffnen? Geben Sie die jeweilige Zahl ein.");
                    Console.WriteLine();
                    Console.WriteLine("Geben Sie \"zurück\" ein, wenn Sie zurück in das Hauptmenü wollen.");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.WriteLine();
                    Console.Write("Ihre Eingabe: ");
                    //Deklarieren und Initialisieren der Variablen eingabeAuswahl mit der Methode prüfenAufGanzzahl
                    int eingabeAuswahl;
                    eingabeAuswahl = prüfenAufGanzzahl();
                    Console.WriteLine();
                    //Rückgabe der Variablen eingabeAuswahl
                    return eingabeAuswahl;
                }


                static void eingabeBeliebig()
                {
                    //prüfen ob menüAuswahlEingabe 7 ist
                    if (menüAuswahlEingabe == 7)
                    {
                        //initialisieren der Variablen Auswahl
                        Auswahl = 5;
                        //Ausgaben in der Konsole
                        Console.Clear();
                        Console.WriteLine($"Sie geben ein Fahrzeug vom Typ \"beliebig\" ein.");
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine();
                        Console.WriteLine("Geben Sie \"zurück\" ein, wenn Sie zurück in das Hauptmenü wollen.");
                        Console.WriteLine("Geben Sie \"weiter\" ein, wenn Sie weitermachen wollen.");
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine();
                        Console.Write("Ihre Eingabe: ");
                        //initialisieren der Variablen eingabeZurück mit der Methode prüfenAufGanzzahl
                        eingabeZurück = prüfenAufGanzzahl();
                        //prüfen ob eingabeZurück -1 ist
                        if (eingabeZurück == -1)
                        {
                            eingabeZurück = -1;
                        }
                        else
                        {
                            //Ausgabe verschiedener Dinge in der Konsole und teilweise deklarieren und initialisieren von Variablen
                            Console.WriteLine("________________________________________________________________________________________________________________________");
                            Console.WriteLine();
                            Console.Write("Gib deine Fahrzeugart ein: ");
                            fahrzeugEingabeName = prüfenAufEingabe();
                            Console.Write("Gib deinem Fahrzeug einen Namen: ");
                            eingabeName = doppelteFahrzeugePrüfen();
                            Console.Write($"Gib deine Fahrzeugmarke ein: ");
                            string eingabeMarke = prüfenAufEingabe();
                            Console.Write("Gib deine Fahrzeugfarbe ein: ");
                            string eingabeFarbe = prüfenAufEingabe();
                            Console.Write("Gib deine Kraftstoffart ein: ");
                            string eingabeKraftstoff = prüfenAufEingabe();
                            Console.Write($"Gib die Anzahl der Räder deines Fahrzeuges ein: ");
                            int eingabeAnzahlRäder;
                            eingabeAnzahlRäder = prüfenAufGanzzahl();
                            string eingabeAnzahlRäder1 = "" + eingabeAnzahlRäder;
                            Console.Write($"Gib deine maximale Höchstgeschwindigkeit ein: ");
                            int eingabeMaxHöchstGeschw;
                            eingabeMaxHöchstGeschw = prüfenAufGanzzahl();
                            string eingabeMaxHöchstGeschw1 = "" + eingabeMaxHöchstGeschw;
                            string eingabeStatus = "parkt";
                            //initialisieren eines neuen Objektes mit den vorher festgelegten Variablen
                            Fahrzeuge fahrzeug = new Fahrzeuge(fahrzeugEingabeName, eingabeName, eingabeMarke, eingabeFarbe, eingabeKraftstoff, eingabeAnzahlRäder1, eingabeMaxHöchstGeschw1, eingabeStatus);
                        }
                    }
                    else
                    {
                        //initialisieren der Variablen Auswahl
                        Auswahl = 5;
                        //Ausgaben in der Konsole
                        Console.Clear();
                        Console.WriteLine($"Sie geben ein Fahrzeug vom Typ \"{fahrzeugEingabeName}\" ein.");
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine();
                        Console.WriteLine("Geben Sie \"zurück\" ein, wenn Sie zurück in das Hauptmenü wollen.");
                        Console.WriteLine("Geben Sie \"weiter\" ein wenn nicht.");
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine();
                        Console.Write("Ihre Eingabe: ");
                        //initialisieren der Variablen Menüs
                        Menüs = 4;
                        //initialisieren der Variablen eingabeZurück mit der Methode prüfenAufGanzzahl
                        eingabeZurück = prüfenAufGanzzahl();
                        //prüfen ob eingabeZurück -1 ist
                        if (eingabeZurück == -1)
                        {
                            eingabeZurück = -1;
                        }
                        else
                        {
                            //Ausgabe verschiedener Dinge in der Konsole und teilweise deklarieren und initialisieren von Variablen
                            Console.WriteLine("________________________________________________________________________________________________________________________");
                            Console.WriteLine();
                            Console.Write("Gib deinem Fahrzeug einen Namen: ");
                            eingabeName = doppelteFahrzeugePrüfen();
                            Console.Write($"Gib deine Fahrzeugmarke ein: ");
                            string eingabeMarke = prüfenAufEingabe();
                            Console.Write("Gib deine Fahrzeugfarbe ein: ");
                            string eingabeFarbe = prüfenAufEingabe();
                            string eingabeKraftstoff;
                            if (menüAuswahlEingabe == 2 || menüAuswahlEingabe == 4 || menüAuswahlEingabe == 5 || menüAuswahlEingabe == 6)
                            {
                                Console.WriteLine("Dein Fahrzeug kann keinen Kraftstoff tanken.");
                                eingabeKraftstoff = "-";
                            }
                            else
                            {
                                Console.Write("Gib deine Kraftstoffart ein: ");
                                eingabeKraftstoff = prüfenAufEingabe();
                            }
                            Console.Write($"Gib die Anzahl der Räder deines Fahrzeuges ein: ");
                            int eingabeAnzahlRäder;
                            eingabeAnzahlRäder = prüfenAufGanzzahl();
                            string eingabeAnzahlRäder1 = "" + eingabeAnzahlRäder;
                            Console.Write($"Gib deine maximale Höchstgeschwindigkeit ein: ");
                            int eingabeMaxHöchstGeschw;
                            eingabeMaxHöchstGeschw = prüfenAufGanzzahl();
                            string eingabeMaxHöchstGeschw1 = "" + eingabeMaxHöchstGeschw;
                            string eingabeStatus = "parkt";
                            Fahrzeuge fahrzeug = new Fahrzeuge(fahrzeugEingabeName, eingabeName, eingabeMarke, eingabeFarbe, eingabeKraftstoff, eingabeAnzahlRäder1, eingabeMaxHöchstGeschw1, eingabeStatus);                                                        
                        }
                    }
                }

                static void StatusMenü()
                {
                    //Ausgaben in der Konsole
                    Console.WriteLine("Statusaktualisiserung");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.WriteLine();
                    Console.WriteLine("1. Status: parkt");
                    Console.WriteLine("2. Status: fährt");
                    Console.WriteLine("3. Status: tankt");
                    Console.WriteLine("4. Status: Wartung");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                }


                static void StatusAuswahl()
                {
                    //Aufrufen der Methode fahrzeugStatusAuswahl
                    fahrzeugStatusAuswahl();
                    //Prüfen ob alleFahrzeuge.Count 0 ist
                    if (alleFahrzeuge.Count == 0)
                    {
                        //Ausgaben in der Konsole
                        Console.WriteLine();
                        Console.WriteLine("Es ist kein Fahrzeug hinterlegt. Hinterlege ein Fahrzeug um den Status anzupassen.");
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine("\nDrücken Sie Enter um zurück ins Menü zu gelangen.");
                        Console.ReadLine();
                    }
                    else
                    {
                        //Ausgaben in der Konsole
                        Console.WriteLine();
                        Console.WriteLine("Geben Sie den Namen von dem Fahrzeug ein, dessen Status Sie verändern wollen.");
                        Console.Write("Ihre Eingabe: ");
                        Console.WriteLine();
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        //Deklarieren und Initialisieren der Variablen name
                        string name = Console.ReadLine();
                        //Aufrufen einer for-Schleife
                        for (int x = 0; x < alleFahrzeuge.Count; x++)
                        {
                            //prüfen ob ein Fahrzeug mit dem Namen des eingegebenen Namens besteht
                            if (alleFahrzeuge[x][1] == name)
                            {
                                //Ausgaben in der Konsole
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Sie bearbeiten den Status des Fahrzeuges " + name);
                                Console.WriteLine("________________________________________________________________________________________________________________________");
                                Console.WriteLine();
                                Console.WriteLine("Geben Sie die Zahl des Status ein, welchen Sie als neuen Status festlegen wollen.");
                                //Deklaration und Initialisierung der Variablen eingabeAuswahl mit der methode prüfenAufGanzzahl
                                int eingabeAuswahl;
                                eingabeAuswahl = prüfenAufGanzzahl();
                                //Aufrufen einer switch-case-Funktion zum Festlegen eines neuen Status des jeweiligen Fahrzeugs
                                switch (eingabeAuswahl)
                                {
                                    case 1:
                                        alleFahrzeuge[x][7] = "parkt";
                                        break;
                                    case 2:
                                        alleFahrzeuge[x][7] = "fährt";
                                        break;
                                    case 3:
                                        alleFahrzeuge[x][7] = "tankt";
                                        break;
                                    case 4:
                                        alleFahrzeuge[x][7] = "Wartung";
                                        break;
                                }

                                /*
                                if (eingabeAuswahl == 1)
                                {
                                    alleFahrzeuge[x][7] = "parkt";
                                }
                                else
                                {
                                    if (eingabeAuswahl == 2)
                                    {
                                        alleFahrzeuge[x][7] = "fährt";
                                    }
                                    else
                                    {
                                        if (eingabeAuswahl == 3)
                                        {
                                            alleFahrzeuge[x][7] = "tankt";
                                        }
                                        else
                                        {
                                            if (eingabeAuswahl == 4)
                                            {
                                                alleFahrzeuge[x][7] = "Wartung";
                                            }
                                        }
                                    }
                                }
                                */
                            }

                        }
                        //Deklarieren und Initialisieren der Variablen json
                        string json;
                        //Initialisieren der Variablen json mit der Liste allFahrzeuge und Formatieren der Objekte
                        json = JsonConvert.SerializeObject(alleFahrzeuge, Formatting.Indented);
                        //Ersetzen der Datei Fahrzeuge im Pfad mit der neuen json
                        File.WriteAllText(jsonPfad, json);
                        //Ausgabe in der Konsole 
                        Console.WriteLine("Drücken Sie Enter um zurück ins Menü zu kommen.");
                        Console.ReadLine();
                    }
                }

                static void StatusÜbersichtMenü()
                {
                    //Ausgaben in der Konsole und Aufrufen der Methode fahrzeugStatusAuswahl
                    Console.Clear();
                    Console.WriteLine("Status der Fahrzeuge");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.WriteLine();
                    Console.WriteLine("Den Status von welchem Fahrzeug möchtest du dir anzeigen lassen?");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    fahrzeugStatusAuswahl();
                    Console.WriteLine();
                    Console.WriteLine("Gib den namen des Fahrzeugs ein. ");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.WriteLine();
                }

                static void StatusNamenAuswahl()
                {
                    //prüfen ob alleFahrzeuge.Count 0 ist
                    if (alleFahrzeuge.Count == 0)
                    {
                        //Ausgaben in der Konsole
                        Console.WriteLine("Es ist kein Fahrzeug hinterlegt. Hinterlege ein Fahrzeug um den Status anzupassen.");
                        Console.WriteLine("Drücken Sie Enter um zurück ins Menü zu gelangen.");
                    }
                    else
                    {
                        //Ausgaben in der Konsole
                        Console.WriteLine();
                        Console.Write("Ihre Eingabe: ");
                        //Deklarieren und Initialisieren der Variablen name
                        string name = Console.ReadLine();

                        //Aufrufen einer for-Schleife
                        for (int x = 0; x < alleFahrzeuge.Count; x++)
                        {
                            //Prüfen ob name = alleFahrzeuge an der Stelle x,1
                            if (alleFahrzeuge[x][1] == name)
                            {
                                //Ausgaben in der Konsole
                                Console.WriteLine("________________________________________________________________________________________________________________________");
                                Console.WriteLine();
                                Console.WriteLine(alleFahrzeuge[x][1] + " hat den Status: " + alleFahrzeuge[x][7]);
                                Console.WriteLine("________________________________________________________________________________________________________________________");
                                Console.ReadLine();
                            }

                        }
                    }
                }

                static void fahrzeugStatusAuswahl()
                {
                    //Prüfen ob alleFahrzeuge.Count größer als 0 ist
                    if (alleFahrzeuge.Count > 0)
                    {
                        //Ausgaben in der Konsole für jedes Fahrzeug
                        Console.WriteLine();
                        for (int x = 0; x < alleFahrzeuge.Count; x++)
                        {
                            Console.WriteLine(alleFahrzeuge[x][1]);
                        }
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                    }
                    else
                    {
                        //Ausgaben in der Konsole
                        Console.WriteLine();
                        Console.WriteLine("Keine Daten Vorhanden.");
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                    }
                }

                static string prüfenAufEingabe()
                {
                    //Deklaration und Initialisierung der Variablen eingabe
                    string eingabe = Console.ReadLine();
                    while (eingabe == "")
                    {
                        //Ausgaben in der Konsole, mit Prüfung ob menüAuswahlEingabe 7 ist
                        Console.Clear();
                        if (menüAuswahlEingabe == 7)
                        {
                            Console.WriteLine($"Sie geben ein Fahrzeug vom Typ \"beliebig\" ein.");
                            Console.WriteLine("________________________________________________________________________________________________________________________");
                        }
                        else
                        {
                            Console.WriteLine($"Sie geben ein Fahrzeug vom Typ \"" + fahrzeugEingabeName + "\" ein.");
                            Console.WriteLine("________________________________________________________________________________________________________________________");
                        }
                        Console.WriteLine("\nVersuchen Sie es nochmal.");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Ihre Eingabe: ");
                        //Initialisieren der Variablen eingabe
                        eingabe = Console.ReadLine();
                        //Prüfen ob für eingabe nichts eingegeben wurde
                        if (eingabe == "")
                        {
                            //Ausgaben in der Konsole
                            Console.WriteLine("________________________________________________________________________________________________________________________");
                            Console.WriteLine();
                            Console.WriteLine("Es muss etwas eingegeben werden.");
                            Console.WriteLine("Drücken Sie Enter um es nochmal zu probieren.");
                            Console.ReadLine();
                        }
                    }
                    //Rückgabe des Wertes eingabe
                    return eingabe;
                }



                static string doppelteFahrzeugePrüfen()
                {
                    //Initialisieren und Deklarieren der Variablen name mit der Methode prüfenAufEingabe und erfolg
                    string name = prüfenAufEingabe();
                    bool erfolg = true;
                    //Aufrufen einer for-Schleife
                    for (int x = 0; x < alleFahrzeuge.Count; x++)
                    {
                        //Prüfen ob die Variable name = alleFahrzeuge an der Stelle x,1 ist
                        if (name == alleFahrzeuge[x][1])
                        {
                            //initialisieren der Variablen erfolg
                            erfolg = false;
                            break;
                        }
                    }
                    //Aufrufen einer while-Schleife
                    while (erfolg == false)
                    {
                        //Ausgaben in der Konsole und Überprüfung ob menüAuswahlEingabe 7 ist
                        Console.Clear();
                        if (menüAuswahlEingabe == 7)
                        {
                            Console.WriteLine($"Sie geben ein Fahrzeug vom Typ \"beliebig\" ein.");
                            Console.WriteLine("________________________________________________________________________________________________________________________");
                        }
                        else
                        {
                            Console.WriteLine($"Sie geben ein Fahrzeug vom Typ \"" + fahrzeugEingabeName + "\" ein.");
                            Console.WriteLine("________________________________________________________________________________________________________________________");
                        }
                        Console.WriteLine("\nDieses Fahrzeug besteht bereits. Versuchen Sie es nochmal.");
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine();
                        Console.Write("Ihre Eingabe: ");
                        //initialisieren der Variablen name mit der methode prüfenAufEingabe
                        name = prüfenAufEingabe();
                        //Deklaration und Initialisierung der Variablen zähler, x und misserfolg
                        int zähler = 1;
                        int x = 0;
                        int misserfolg = 0;
                        //Aufrufen einer while-Schleife
                        while (x < alleFahrzeuge.Count)
                        {
                            //Prüfen ob die Variable name = alleFahrzeuge an der Stelle x,1 ist
                            if (name == alleFahrzeuge[x][1])
                            {
                                //initialisieren der Variablen erfolg, misserfolg und erweitern von zähler um 1
                                erfolg = false;
                                misserfolg = 1;
                                zähler++;
                            }
                            else
                            {
                                //erweitern der Varaiblen zähler
                                zähler++;
                            }
                            //prüfen ob zähler = alleFahrzeuge.Count + 1 ist und ob misserfolg 0 ist
                            if (zähler == alleFahrzeuge.Count + 1 && misserfolg == 0)
                            {
                                //initialisieren der Variablen erfolg
                                erfolg = true;
                            }
                            //initialisieren der Variablen x
                            x++;
                        }

                    }
                    //rückgabe der Variablen name
                    return name;
                }


                

                static int prüfenAufGanzzahl()
                {
                   

                    //Deklarieren und Initialisieren der Variablen eingabeAuswahlEingabe, eingabeAuswahl und erfolg
                    string eingabeAuswahlEingabe = Console.ReadLine();
                    int eingabeAuswahl;
                    //Überprüfen, ob eingabeAuswahlEingabe in einen Integer konvertiert werden kann
                    bool erfolg = int.TryParse(eingabeAuswahlEingabe, out eingabeAuswahl);
                    //Überprüfen ob für eingabeAuswahlEingabe nichts eingegeben wurde und initialisieren der Variablen eingabeZurück
                    switch (eingabeAuswahlEingabe)
                    {
                        case "":
                            eingabeZurück = -2;
                            break;
                        default:
                            switch (Auswahl)
                            {
                                case 0:
                                    switch (eingabeAuswahlEingabe)
                                    {
                                        case "Stopp":
                                            programmStopp = "Stopp";
                                            break;
                                        case "zurück":
                                            eingabeAuswahl = -1;
                                            break;
                                        case "weiter":
                                            eingabeZurück = -2;
                                            break;
                                        default:
                                            while (erfolg == false || eingabeAuswahl > 3 || eingabeAuswahl <= 0)
                                            {
                                                //Ausgaben in der Konsole
                                                Console.WriteLine();
                                                Console.WriteLine("Es muss eine ganze Zahl eingegeben werden, welche im Bereich der möglichen Auswahl liegt.");
                                                Console.WriteLine("Drücken Sie Enter um es nochmal zu probieren.");
                                                Console.ReadLine();
                                                Console.Clear();

                                                switch (Menüs)
                                                {
                                                    case 1:
                                                        MenüAusgabe();
                                                        break;
                                                    case 2:
                                                        FahrzeugMenü();
                                                        break;
                                                    case 3:
                                                        fahrzeugAusgabe();
                                                        break;
                                                }
                                                //Ausgaben in der Konsole
                                                Console.WriteLine("\nWelchen Punkt wollen Sie öffnen? Geben Sie die jeweilige Zahl ein.");
                                                Console.WriteLine();
                                                Console.WriteLine();
                                                Console.Write("Ihre Eingabe: ");
                                                //Initialisieren der Variablen eingabeAuswahlEingabe und erfolg mti Überprüfung ob das Konvertieren der
                                                //Variablen eingabeAuswahlEingabe zum Integer möglich ist
                                                eingabeAuswahlEingabe = Console.ReadLine();
                                                erfolg = int.TryParse(eingabeAuswahlEingabe, out eingabeAuswahl);
                                                //Prüfen ob die eingabeAuswahlEingabe zurück ist
                                                if (eingabeAuswahlEingabe == "zurück")
                                                {
                                                    //initialisieren der Variablen eingabeAuswahl und erfolg
                                                    eingabeAuswahl = -1;
                                                    erfolg = true;
                                                }
                                                else
                                                {
                                                    //Prüfen ob eingabeAuswahlEingabe = weiter ist
                                                    if (eingabeAuswahlEingabe == "weiter")
                                                    {
                                                        //initialisieren der Variablen eingabeAuswahl und erfolg
                                                        eingabeAuswahl = -2;
                                                        erfolg = true;
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                    break;
                                default:
                                    switch (eingabeAuswahlEingabe)
                                    {
                                        case "Stopp":
                                            programmStopp = "Stopp";
                                            break;
                                        case "zurück":
                                            eingabeAuswahl = -1;
                                            break;
                                        case "weiter":
                                            eingabeZurück = -2;
                                            break;
                                        default:
                                            if (Auswahl == 5)
                                            {
                                                //Aufrufen einer while-Schleife
                                                while (erfolg == false)
                                                {
                                                    //Ausgaben in der Konsole
                                                    Console.WriteLine("________________________________________________________________________________________________________________________");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Ungültige Eingabe.");
                                                    Console.WriteLine("Drücken Sie Enter um es nochmal zu probieren.");
                                                    Console.ReadLine();
                                                    Console.Clear();
                                                    //switch-case-Anweisung zur Ausgabe von Dingen in der Konsole
                                                    switch (Menüs)
                                                    {
                                                        case 1:
                                                            MenüAusgabe();
                                                            break;
                                                        case 2:
                                                            FahrzeugMenü();
                                                            break;
                                                        case 3:
                                                            fahrzeugAusgabe();
                                                            break;
                                                        case 4:
                                                            if (menüAuswahlEingabe == 7)
                                                            {
                                                                fahrzeugBeliebigAusgabe();
                                                            }
                                                            else
                                                            {
                                                                fahrzeugDefiniertAusgabe();
                                                            }
                                                            break;
                                                    }
                                                    //Ausgaben in der Konsole
                                                    Console.WriteLine("\nVersuchen Sie es nochmal.");
                                                    Console.WriteLine("________________________________________________________________________________________________________________________");
                                                    Console.WriteLine();
                                                    Console.Write("Ihre Eingabe: ");
                                                    //initialisieren der Variablen eingabeAuswahlEingabe
                                                    eingabeAuswahlEingabe = Console.ReadLine();
                                                    //Prüfen ob eingabeAuswahlEingabe zurück ist
                                                    if (eingabeAuswahlEingabe == "zurück")
                                                    {
                                                        //initialisieren der Variablen eingabeAuswahl und eingabeZurück
                                                        eingabeAuswahl = -1;
                                                        eingabeZurück = -1;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        //Prüfen ob eingabeAuswahlEingabe weiter ist
                                                        if (eingabeAuswahlEingabe == "weiter")
                                                        {
                                                            //initialisieren der Variablen eingabeZurück
                                                            eingabeZurück = -2;
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            //initialisieren der Variablen erfolg mit der Überprüfung ob eingabeAuswahlEingabe konvertierbar zu
                                                            //einem Integer ist
                                                            erfolg = int.TryParse(eingabeAuswahlEingabe, out eingabeAuswahl);
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                //Rückgabe der Variablem eingabeAuswahl
                return eingabeAuswahl;
                }

                static void fahrzeugBeliebigAusgabe()
                {
                    //Ausgaben in der Konsole
                    Console.WriteLine($"Sie geben ein Fahrzeug vom Typ \"beliebig\" ein.");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.WriteLine();
                    Console.WriteLine("Geben Sie \"zurück\" ein, wenn Sie zurück in das Hauptmenü wollen.");
                    Console.WriteLine("Geben Sie \"weiter\" ein, wenn Sie weitermachen wollen.");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                }

                static void fahrzeugDefiniertAusgabe()
                {
                    //Ausgaben in der Konsole
                    Console.WriteLine($"Sie geben ein Fahrzeug vom Typ \"" + fahrzeugEingabeName + "\" ein.");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.WriteLine();
                    Console.WriteLine("Geben Sie \"zurück\" ein, wenn Sie zurück in das Hauptmenü wollen.");
                    Console.WriteLine("Geben Sie \"weiter\" ein, wenn Sie weitermachen wollen.");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                }

                static void AusgabeAllerFahrzeuge()
                {
                    //Ausgaben in der Konsole
                    Console.Clear();
                    Console.WriteLine("Fahrzeugliste");
                    Console.WriteLine("________________________________________________________________________________________________________________________");
                    Console.WriteLine();
                    //Prüfen ob alleFahrzeuge.Count 0 ist
                    if (alleFahrzeuge.Count > 0)
                    {
                        //Aufrufen einer for-Schleife
                        for (int x = 0; x < alleFahrzeuge.Count; x++)
                        {
                            //Ausgabe der Objekte an zugewiesenen Stellen
                            Console.WriteLine("{0,-10} {1, -2} {2, -20} {3, -2} {4, -15} {5, -2} {6, -15} {7, -2} {8,-10} {9, -2} {10, -5} {11, -2} {12, -5} {13, -2} {14, -15}",
                                alleFahrzeuge[x][0], "|", alleFahrzeuge[x][1], "|", alleFahrzeuge[x][2], "|", alleFahrzeuge[x][3], "|", alleFahrzeuge[x][4], "|", alleFahrzeuge[x][5],
                                "|", alleFahrzeuge[x][6], "|", alleFahrzeuge[x][7]);
                        }
                    }
                    else
                    {
                        //Ausgabe in der Konsole
                        Console.WriteLine("Es ist kein Fahrzeug hinterlegt. Hinterlege Fahrzeuge um etwas Ausgeben lassen zu können.");
                    }
                }
            }
        }
        public class Fahrzeuge
        {
            //Deklarieren von Variablen für die gesamte Klasse
            static string name;
            static string eigName;
            static string marke;
            static string farbe;
            static string eingabeKraftstoff;
            static string anzahlRäder;
            static string maxHöchstGeschw;
            static string eingabeStatus;
            public Fahrzeuge(string name1, string eigName1,
                             string marke1, string farbe1, 
                             string eingabeKraftstoff1, 
                             string anzahlRäder1, 
                             string maxHöchstGeschw1, 
                             string eingabeStatus1)
            {
                //initialisieren der Variablen
                name = name1;
                eigName = eigName1;
                marke = marke1;
                farbe = farbe1;
                eingabeKraftstoff = eingabeKraftstoff1;
                anzahlRäder = anzahlRäder1;
                maxHöchstGeschw = maxHöchstGeschw1;
                eingabeStatus = eingabeStatus1;
                //Konvertieren der Variablen anzahlRäder
                Convert.ToString(anzahlRäder);
                //Aufrufen der Methode eingabeFahrzeuge
                eingabeFahrzeuge();
            }

            static void eingabeFahrzeuge()
            {
                //Deklarieren und Initialisieren der Liste fahrzeug und hinzufügen aller Variablen
                List<string> fahrzeug = new List<string>();
                fahrzeug.Add(name);
                fahrzeug.Add(eigName);
                fahrzeug.Add(marke);
                fahrzeug.Add(farbe);
                fahrzeug.Add(eingabeKraftstoff);
                fahrzeug.Add(anzahlRäder);
                fahrzeug.Add(maxHöchstGeschw);
                fahrzeug.Add(eingabeStatus);
                alleFahrzeuge.Add(fahrzeug);
                //deklarieren und Initialisieren der Variablen json mit der Liste alleFahrzeuge und anschließende Formatierung des Strings
                string json;
                json = JsonConvert.SerializeObject(alleFahrzeuge, Formatting.Indented);
                //Ersetzen des bestehenden Pfades mit neuem json String
                File.WriteAllText(jsonPfad, json);
            }
        }
    }
}
        
