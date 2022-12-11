create database DumDum_Star;
use DumDum_Star;

create table Corporation (
	id int primary key auto_increment,
    `name` nvarchar(64) not null,
    monetary_value  decimal(18, 2) not null,
    members int not null check (members > 0)
);

create table Cyber_ware_type (
	id int primary key auto_increment,
    `name` nvarchar(64) not null,
    target_part nvarchar(64)
);

create table Cyber_ware (
	id int primary key auto_increment,
    type_id int references cyber_ware_type (id),
    manufacturer_id int references Corporation(id),
    quantity int not null check (quantity >= 0),
    
    custom bool not null default true,
    
    `name` nvarchar(64) not null,
    price decimal(9, 2) not null check (price > 0),
    load_level float null default 0.05,
    ranking float null default 3.5 check (ranking > 0 and ranking <= 5.0)
);

create table address (
	id int primary key auto_increment,
    city nvarchar(48) not null,
    region nvarchar(48) null,
    street nvarchar(48) not null
);

create table choom (
	id int primary key auto_increment,
    login nvarchar(32) not null unique,
    `password` nvarchar(48) not null
);

create table `admin` (
	id int primary key auto_increment,
    choom_id int not null references choom(id)
);

create table `client` (
	id int primary key auto_increment,
    choom_id int not null references choom(id)
);

create table `order` (
	id int primary key auto_increment,
    choom_id int not null references choom(id),
    address_id int not null references address(id)
);
