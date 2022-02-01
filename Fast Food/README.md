# Fast Food #
This project is just to prove that I had some experience even writing a bad thing, there is a much better version of it which can be found [here](https://github.com/Abdelrhman-Samir-99/Projects/tree/master/Food%20Diary). <br/>
A basic restaurant system with some features for generating reports for the manager. <br/>
I saw this academic project as a chance to learn more about design patterns.<br/>

## Functional Requirements ##
There are two entities in the project which are (Manager - Cashier).
+ Cashier can do the following:
    + Make an order.
    + Check his logs for today.
+   Manager can do the following:
    + He can delete a specific order.   
    + He can control meals:
        + adding a meal.
        + removing a meal.
    + He also controls his employees:
        + Adding new employees.
        + Removing existing employees.
    + He can generate basic types of reports:
        + He can query all orders at a specific time (day or month or year)
        + He can also query the database using a meal name.

## Design Patterns ##
+ Singleton
    + To make sure that I make only one connection to the database.
+ Proxy
    + It was just another layer of security, instead of accessing the database directly.
+ Iterator
    + I was caching the data on the client-side, in sort of complex dictionaries.
    + I used the iterator pattern to interact with these complex dictionaries. 
+ Builder
    + To construct the whole order:
        + Adding or increasing the count of a specific meal.
        + Deleting the current order or part of it.
        + Editing the current order.
        + Printing the component of the current order.
+ Facade
    + To make it easier to deal with the entire system (interacting with different objects).

## Database ##
### Schema ###
<p align = "center" width = "100%">
    <img src= "https://github.com/Abdelrhman-Samir-99/Projects/blob/master/Fast%20Food/ScreenShots/Schema.jpg"> 
</p>
<br/>

#### Notes ####
+ I know that there is no FK which means there is no referential integrity or even relations between tables.
+ The meal consists of a single item:
    + it can not be composite of multiple existing meals.
+ I don't really think that I had a fair understanding of relational databases at that time (2018).
+ I fixed both of these problems in the other project (a much better version than this one).
## ScreenShots ##

<p align="center" width="100%">
    <img src= "https://github.com/Abdelrhman-Samir-99/Projects/blob/master/Fast%20Food/ScreenShots/LogIn.jpg"> 
    <img src= "https://github.com/Abdelrhman-Samir-99/Projects/blob/master/Fast%20Food/ScreenShots/Manager.jpg"> 
</p>

### Making Order ###

<p align="center" width="100%">
    <img src= "https://user-images.githubusercontent.com/77211992/134443433-d42a6f96-8d43-4e41-9239-a9f2561a4107.png"> 
    <img src= "https://user-images.githubusercontent.com/77211992/134443450-177cfe69-f152-4d02-b0c8-fb0be0dbd38f.png"> 
</p>



### Report by meal ###

<p align="center" width="100%">
    <img src= "https://user-images.githubusercontent.com/77211992/134443461-764b7a83-3e89-4e6e-b3a1-1980891c6929.png"> 
</p>

### Report by date ###

<p align="center" width="100%">
    <img src= "https://user-images.githubusercontent.com/77211992/134443493-9147c52f-cb58-4e20-a1ee-4a7db4b193bb.png"> 
</p>

### Report of the day ###
<p align="center" width="100%">
    <img src= "https://user-images.githubusercontent.com/77211992/134443505-4f30b681-f904-4924-b2da-c8773109faba.png"> 
</p>
