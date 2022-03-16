DaimlerTSS_Coding_Task v1.0.2


## Projekt:
Konsolenanwendung um eine Liste von Intervallen zu erzeugen und diese zu mergen. 

Das Projekt unterteilt sich in 3 Teile:
1. /Coding_Task_Program: 			Ausführbares Programm für Windows-Plattformen.
2. /DaimlerTSS_Coding_Task: 		Visual-Studio-Projekt und Source-Dateien.
3. /DaimlerTSS_Coding_Task_Tests: 	Ausführbare Tests mit Visual Studio.

## Entwicklungsumgebung:
Das Projekt wurde in C# mithilfe von Visual-Studio und .net5 geschrieben.

## Beispiel:
Input: [25,30] [2,19] [14, 23] [4,8]  Output: [2,23] [25,30]

## Bearbeitungszeit
15 h



Fragen:

1. "Wie ist die Laufzeit Ihres Programms ?" 

	Die Laufzeit dieses Programmes ist O(n²), auch im Best-Case. (Wobei n = Anzahl der Intervalle)
	Bemerkungen: 
	Der Algorithmus könnte durch Sortierung noch auf O(n log n) optimiert werden. 
	Zudem müssten Intervalle die schon mal Gemerged wurden nicht mehr angeschaut werden, sodass die mittlere Laufzeit noch gesteigert werden könnte.
	
2. "Wie kann die Robustheit sichergestellt werden, vor allem auch mit Hinblick auf sehr große Eingaben ?"

	- Das Programm sollte die größe der Eingabe vor Ausführung prüfen um keinen Overflow im Arbeitsspeicher zu verursachen. (Je nach Betriebssystem ist eine Auslagerung auf die Festplatte, mit Leistungseinbußen, natürlich möglich. Es sei denn die Daten sind größer als die Festplatte. )
	- Insbesondere bei großen Daten muss der reservierte Speicherplatz für nicht mehr benötigte Objekte und primitive Datentypen zuverlässig freigegeben werden. 
		Wird in der Regel mit "Garbage-Collector" automatisch umgesetzt. Bei Rekursion jedoch, kann der Speicher auf dem Stack nicht freigegeben werden. 
		-> Daher Rekursion vermeiden bei sehr großen Daten.
	- Auch einzelne Funktionen sollten Übergabeparameter überprüfen und im Falle ungültiger Parameter Exceptions werfen.
	- Unvorhergesehene (externe) Fehler sollten möglichst abgefangen werden, z.B. mit "trycatch". (z.B. bei "Datei nicht gefunden")
	- Logging für die Nachvollziehbarkeit und Debugging. Für komplexe Programme, in denen nicht alle Eventualitäten getestet werden können, notwendig um Robustheit im nachhinein zu steigern.
	- Funktionsweise von externe Libraries auf ungünstige Speicherbelegung überprüfen.
	- Grenzwerte von externen Libraries in Dokumentation überprüfen.
	
3. "Wie verhält sich der Speicherverbrauch ihres Programms ?"
	
	- Speicheraufwand = 2n (wobei n = Anzahl der Intervalle)
	- Der Speicheraufwand bezieht sich auf die übergebene Liste mit Intervallen und die Liste mit Intervallen die zurückgegeben wird. 
		Die restlichen Datentypen werden nur temporär angelegt und summieren sich nicht über die Laufzeit. Daher kann man diese vernachlässigen.
	- Speicheraufwand kann noch auf i reduziert werden, wenn die übergebene Liste gemerged und zurückgegeben wird. 
		Nach gänginger Programmier-Notationen sollte darauf jedoch verzichtet werden.
