# PROG7311_FarmersHub

# GitHub Link

https://github.com/Rhian777/PROG7311_FarmersHub.git](https://github.com/VCCT-PROG3A-2025-G1/RhianHeralall_ST10247368_PROG7311_FarmersHub.git

# FarmersHub – Agri-Energy Connect Prototype

This ASP.NET Core MVC web application serves as a prototype for the FarmersHub platform. It enables two user roles: **Farmers** and **Employees**, each with specific functionality.

## Features

### Authentication & Roles
- **Farmers** can:
  - Add products
  - View their own products

- **Employees** can:
  - Add new farmers
  - View all farmers
  - Filter/view products by category and date

## Demo Login Details

| Role     | Email                     | Password       |
|----------|---------------------------|----------------|
| Farmer   | `farmer1@example.com`     | `Password123!` |
| Employee | `employee1@example.com`   | `Password123!` |

## How it Works

This web application simulates the Agri-Energy Connect platform by managing two types of users: Farmers and Employees.

Farmers log in to add agricultural products and view their own submissions.

Employees can register new farmers and view/filter products across all farms, after login.

The system uses ASP.NET Identity for role-based access control, with separate views and controller actions depending on user roles. All data is stored in a local SQLite database and seeded with sample accounts and products on first launch.

## Changes Made Since Part 2 Submission

All functionality has been applied and test, all above-mentioned features are now full operational

Ability to Add Farmers (for employees) have been improved to redirect user to list of Farmers, allowing user to view changes made.

## Important Note

! NB !

If your folder contains as 'global.json' file indicating the SDK version to use, please perform one of the following options:
1) Edit the SDK version to use '8.0.200'
2) Delete the 'global.json' file before running the project (RECOMMENDED OOPTION)

Depending on your browser security, the project might be flagged as unsage, ignore this warning and advance to the site (After installing and accepting the SSL Certificate)
