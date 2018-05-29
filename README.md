# Animal Adoption Control

Project developed as a personal challenge and for learning purposes.

## Features

**1 - Adopters registering:**  
A web page where people who want to adopt animals may be created, edited and deleted.  

**2 - Animals registering:**  
A web page where animals that might be adopted can be created, edited and deleted.  

**3 - Adoptions control:**   
A web page where the admin can control adoptions.  

***Optional***  
**4 - User authentication.**  

**5 - Social network integration. //TODO**

## Requirements

**1 - Adopters**  
 Adopters should be able to adopt animals.  
 Adopters who have already adopted an animal may not be removed from the system.  

**2 - Animals**  
Animals should be able to be adopted by adopters.  
An animal should be adopted by only one adopter.  

**3 - Adoption**  
The process of an adoption may be presented on a dashboard, containing the adopters name and animals name.  

**4 - Authentication (Optional)**  
Users who want to create, delete and edit animals, adopters or adoptions need to be authenticated.  

**5 - Social network integration (Optional) //TODO**  
The authenticated user may have the option to share animals on social network, like Facebook, for publicity.  

## Installing

**1** - Build for restore packages.  

**2** - This project was developed using EF6 code first. Run the following to get the database ready.  

```
Update-database
```

## Technology

### Language
* *C#*  
* *Javascript*  

### Web
* *ASP.MVC*  
* *JQuery*  
* *Razor*  

### Database
* *Entity Framework 6 - code first*  
* *SQL Server*  

### Tests
* *Unit testing*  
* *NUnit tests framework*  

## NOTES

* *Unit tests on [master](https://github.com/BelvedereHenrique/adoptionControl/tree/master) branch*  
* *Front-end developed using JQuery on [master](https://github.com/BelvedereHenrique/adoptionControl/tree/master)/[JQuery](https://github.com/BelvedereHenrique/adoptionControl/tree/JQuery) branches*  
* *Front-end developed using Razor on [Razor](https://github.com/BelvedereHenrique/adoptionControl/tree/Razor) branch*  


