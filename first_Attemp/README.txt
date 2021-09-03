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
