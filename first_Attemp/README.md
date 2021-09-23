# Restaurant system (Windows Form Application) #
### This project is just to prove that I had some experience even writing a bad thing, there is a much better version of it which can be found [HERE](). ###
##### Application for a cashier to make an order and for the manager to keep track of the employee's activities, Also generate some basic type of reports, it was for an academic course. #####
##### It is not written in clean code since I didn't have much experience at that time. #####
##### Implemented what I learned in software development & visual programming courses. #####

## Design Patterns ##
+ Singleton
    + To make sure that I make only one connection to the database.
+ Proxy
    + Any time I access the database (adding a layer of security).
+ Iterator
    + To iterate over the dictionaries we bring from the database. 
+ Builder
    + To construct the whole order.
        + Adding or increasing the count of a specific meal.
        + Deleting the current order or part of it.
        + Editing the current order.
        + Printing the component of the current order.

+ Facade
    + To make it easier to deal with the whole system (interacting with different objects).

## Database ##
### I used SQL server to save: ###
+ The meals we had.
+ The orders for all time.
+ The employee data.

### Database Schema ###



## ScreenShots ##
![Employee Register](https://raw.githubusercontent.com/SmallCat3699/Projects/master/first_Attemp/ScreenShots/Register.jpg)
![LogIn](https://raw.githubusercontent.com/SmallCat3699/Projects/master/first_Attemp/ScreenShots/LogIn.jpg)
![Manager](https://raw.githubusercontent.com/SmallCat3699/Projects/master/first_Attemp/ScreenShots/Manager.jpg)
#### Making Order ####
![How_To_Order](https://user-images.githubusercontent.com/77211992/134443433-d42a6f96-8d43-4e41-9239-a9f2561a4107.png)
![Making_Order](https://user-images.githubusercontent.com/77211992/134443450-177cfe69-f152-4d02-b0c8-fb0be0dbd38f.png)

#### Report by date ####
![MealReport](https://user-images.githubusercontent.com/77211992/134443461-764b7a83-3e89-4e6e-b3a1-1980891c6929.png)

#### Report by meal ####
![Report_By_Meal](https://user-images.githubusercontent.com/77211992/134443493-9147c52f-cb58-4e20-a1ee-4a7db4b193bb.png)

#### Report of the day ####
![Report_Of_The_Day](https://user-images.githubusercontent.com/77211992/134443505-4f30b681-f904-4924-b2da-c8773109faba.png)

