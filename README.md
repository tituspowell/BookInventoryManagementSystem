# Book Inventory Management System : An ASP.NET Core Project

<br><br>
![TITLE](/screenshots/XXX.PNG)
<br><br>

## Introduction

This is a project I did to solidify my grasp of ASP.NET Core and Entity Framework Core after completing a course. It's a book inventory management system that incorporates identity and permissions - the UI shown and the actions available to them depend on their associated user role. It interacts with a local SQL database and performs CRUD operations for books, book reviews and users.

## Access Levels

There are four access levels, which control what you can do in the system:

1 - **Anonymous**: a user who isn't logged in can view the catalogue of books, look at any book's details and reviews. They also have the option to login and to register.
2 - **Reader**: a Reader is a basic logged in user with no special privileges. In addition to viewing the books and book reviews, they can also leave their own reviews.
3 - **Librarian**: Librarians have additional privileges. They can add and delete books, and edit the details. They can also delete (but not edit) other people's book reviews.
4 - **Administrator**: Administrators can do all of the above and also view users, edit their details and access level, and also delete them if need be.

## Demonstrating the project

This is a tricky project to demonstrate, because a lot of the functionality is hidden if you're not a Librarian or Administrator, and to fully appreciate it you would need to log in and out at different access levels to see the authentication in action. So to keep things simple I'll just include a series of screenshots here with commentary, followed by a brief technical overview and then my thoughts on how the project could be taken further.

## 1 - Anonymous Access

When the user is not logged in, these are the main two views: Book List and Book Details. The latter also shows any reviews for that book.

<br><br>
![TITLE](/screenshots/XXX.PNG)
<br><br>

<br><br>
![TITLE](/screenshots/XXX.PNG)
<br><br>

Note that the columns in the book list are sortable; by clicking on the column header it sorts the list as you would expect, so that, for example, you can list the top rated books first.

## 2 - Reader Access

Now that the user has logged in, they gain access to the review functionality. They can leave reviews directly from the Book List page. On the Book Details page they can also leave a review. If they have previously left a review, that will be shown first, with the option to edit and/or delete it.

<br><br>
![TITLE](/screenshots/XXX.PNG)
<br><br>

<br><br>
![TITLE](/screenshots/XXX.PNG)
<br><br>

<br><br>
![TITLE](/screenshots/XXX.PNG)
<br><br>

<br><br>
![TITLE](/screenshots/XXX.PNG)
<br><br>

## 3 - Librarian Access

Librarians gain the ability to add, edit and delete books, not just reviews. They can also delete other people's reviews.

<br><br>
![TITLE](/screenshots/XXX.PNG)
<br><br>

<br><br>
![TITLE](/screenshots/XXX.PNG)
<br><br>

<br><br>
![TITLE](/screenshots/XXX.PNG)
<br><br>

<br><br>
![TITLE](/screenshots/XXX.PNG)
<br><br>

## 4 - Administrator Access

Administrators can do all of the above and get the ability to add, edit and delete users too.

<br><br>
![TITLE](/screenshots/XXX.PNG)
<br><br>

<br><br>
![TITLE](/screenshots/XXX.PNG)
<br><br>

## Technical Overview

Technical:

Theme

## Future Development

There are many ways this project could be fleshed out, made more robust and taken further if it was actually to be used.
