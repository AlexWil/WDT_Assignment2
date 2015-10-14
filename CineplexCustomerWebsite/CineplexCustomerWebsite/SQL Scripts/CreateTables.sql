USE Clone

create table Cineplex
(
	CineplexID int not null identity primary key,
	Location nvarchar(max) not null,
	ShortDescription nvarchar(max) not null,
	LongDescription nvarchar(max) not null,
	ImageUrl nvarchar(max) null
);

create table Enquiry
(
	EnquiryID int not null identity primary key,
	Email nvarchar(max) not null,
	Message nvarchar(max) not null
);

create table MovieComingSoon
(
	MovieComingSoonID int not null identity primary key,
	Title nvarchar(max) not null,
	ShortDescription nvarchar(max) not null,
	LongDescription nvarchar(max) not null,
	ImageUrl nvarchar(max) null
);

create table Movie
(
	MovieID int not null identity primary key,
	Title nvarchar(max) not null,
	ShortDescription nvarchar(max) not null,
	LongDescription nvarchar(max) not null,
	ImageUrl nvarchar(max) null,
	Price money not null
);

create table Event
(
	EventID int not null identity primary key,
	Title nvarchar(max) not null,
	ShortDescription nvarchar(max) not null,
	LongDescription nvarchar(max) not null,
	EventDateTime date not null
);

create table CineplexMovie
(
	CineplexID int not null foreign key references Cineplex (CineplexID),
	MovieID int not null foreign key references Movie (MovieID),
	primary key (CineplexID, MovieID)
);

create table MovieSession
(
	SessionID int not null identity,
	CineplexID int not null,
	MovieID int not null,
	SessionDateTime [datetime] not null,
	foreign key (CineplexID, MovieID) references CineplexMovie (CineplexID, MovieID),
	primary key (SessionID)

);

create table Seating(
	SeatingID int not null identity,
	Row nvarchar(2) not null,
	SeatNumber int not null,
	SessionID int not null,
	IsTaken bit not null,
	foreign key (SessionID) references MovieSession (SessionID),
	primary key(SeatingID)
);

create table SessionBooking
(
	BookingID int not null identity,
	SessionID int not null foreign key references MovieSession (SessionID),
    UserEmail nvarchar(MAX),
	CineplexID int not null,
	foreign key (CineplexID) references Cineplex (CineplexID),
	primary key (BookingID)

);

create table SessionBookingSeating(
	BookingID int not null,
	SeatingID int not null,
	foreign key (BookingID) references SessionBooking (BookingID),
	foreign key (SeatingID) references Seating (SeatingID),
	primary key(BookingID, SeatingID)
);

