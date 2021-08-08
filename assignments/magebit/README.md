# Web Developer Vacancy Test task

This task tests multiple skills:
- PSD to HTML/CSS
- Javascript
- PHP OOP + MySQL

## Big picture

You will need to create a fully functional login/registration page from PSD.

## Part 1: PSD to HTML/CSS

PSD & Style Guide: [./Photoshop.zip](./Photoshop.zip)

From the given PSD file create HTML/CSS template that will be used in the next tasks. Vue or React framework can be used for this.

Gimp, which is a free tool, can be used to export assets from PSD in case you don’t have access to Photoshop.

Make sure the site is responsive. There is no design for mobile/tablet versions but that shouldn’t be a problem to make sure it’s also usable on mobile. Mobile design won’t be judged, only it’s usability.

## Part 2: Javascript

Animation: https://vimeo.com/153219852 

You need to animate the active field with a white background.

## Part 3: PHP OOP + MySQL

Use MVC pattern to structure your application

Create functionality for:

- Log in (with email and password)
- Registration (must save Full name, e-mail, password)
- Page which can only be accessed by logged in users where attributes can be managed (there is no design for this, page with similar layout as login/registration and an edit form would be enough)*

*Attribute management should provide user to fill in additional information other than name and email. For example, we now want to add age to user profile. Then we want to add something else and so on. Attributes and their values must be stored in a separate tables apart from users and it must be possible to add an unlimited amount of attributes.

Everything is written in plain PHP neither Laravel or Symfony should be used.

Exceptions apply to frameworks/libraries such as Slim or Lumen that handles only routing.

# Submission

Once you have finished this task please send us the code and MySQL dump via email.

NB: Before you submit this task make sure the code is documented (with phpDoc) and without any junk code (code that is commented out, console.log(), var_dump(), etc).
