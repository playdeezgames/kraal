PRAGMA foreign_keys = ON;

CREATE TABLE "universes" (
	"universe_id"	INTEGER,
	"universe_name"	INTEGER NOT NULL UNIQUE,
	"party_id"	INTEGER,
	PRIMARY KEY("universe_id" AUTOINCREMENT),
	FOREIGN KEY("party_id") REFERENCES "parties"("party_id") ON DELETE SET NULL
);

CREATE TABLE "stars" (
	"star_id"	INTEGER,
	"star_name"	TEXT NOT NULL,
	"universe_id"	INTEGER NOT NULL,
	"star_x"	REAL NOT NULL,
	"star_y"	REAL NOT NULL,
	"star_z"	REAL NOT NULL,
	PRIMARY KEY("star_id" AUTOINCREMENT),
	UNIQUE("universe_id","star_name"),
	FOREIGN KEY("universe_id") REFERENCES "universes"("universe_id") ON DELETE CASCADE
);

CREATE TABLE "factions" (
	"faction_id"	INTEGER,
	"faction_name"	TEXT NOT NULL,
	"universe_id"	INTEGER NOT NULL,
	PRIMARY KEY("faction_id" AUTOINCREMENT),
	UNIQUE("universe_id","faction_name"),
	FOREIGN KEY("universe_id") REFERENCES "universes"("universe_id") ON DELETE CASCADE
);

CREATE TABLE "parties" (
	"party_id"	INTEGER,
	"universe_id"	INTEGER NOT NULL,
	PRIMARY KEY("party_id" AUTOINCREMENT),
	UNIQUE("party_id","universe_id"),
	FOREIGN KEY("universe_id") REFERENCES "universes"("universe_id") ON DELETE CASCADE
);