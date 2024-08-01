create table Product
(
    Id       int identity
        primary key,
    Name     nvarchar(255) not null,
    Price    float,
    Category nvarchar(255)
)
go