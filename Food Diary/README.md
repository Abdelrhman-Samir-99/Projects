# Food Diary #
Simple application that help you to keep track of your calories activities.

## System Requirements ##
### Functional Requirements ###
+ There should be two types of Users (Admin - Client)
+ There should be two types of Meals (Public - Private)
  + Public meals are:
    + created only by admins.
    + visible to all users.
  + Private meals are: 
    + made by any user.
    + only visible for the creator.
+ All users can do the following:
  + get all records for a:
    + specific date.
    + range of dates.
  + Can sort (Pulbic & Private) meals by:
    + Type.
    + Calories.
    + Type and Calories.
  + know about his exact weight in the past 30 days.
  + Add records.
+ Admin have all privilages of the client besides:
  + Adding public meals

### Non-Functional Requirements ###


## High level design ##
## initial design ##
<p align="center" width="100%">
    <img src= "https://github.com/SmallCat3699/Projects/blob/master/Food%20Diary/Documentation/High-Level-Design/highLevelDesign.png"> 
</p>

## Database (Models) ##

### Schema ###
![Schema](https://user-images.githubusercontent.com/77211992/151743167-5264c1d2-7b2e-4557-8049-d0c716617c15.svg)
