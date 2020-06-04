# System requirements:
* Installed LocalDb
* .Net Framework not lower that 4.0
* Installed Microsoft Excel 

# BookKeeper
Accounting software.
Main functionality - combining accounts info from excel files with payments from html.

## Technologies:
* Interface - WindowsFroms + MetroUI.
* Database - Localdb, EntityFramework6 + EntityFrameworkPlus.
* Interaction with Excel - ClosedXML + Spire.xls.
* Interaction with Html - Html agility pack.

## Toolbar interface:

### Import:

* Registry  - loading registry from excel files.
* Payments - loading payments from html/htm files.

### Houses:

* Add - adding a house to the database.
* Delete - deleting a house from the database.

### Accounts:

* Highlight unpaid accounts - highlights in red accounts that have arrears for the selected periud. 
* Highlight new - highlights in green the accounts that were first added to the database. 
* Reset - set the default colors.

### Database:

* Backup - creates an instance of the current database.
* Recover - loads the database from a save instance.

## Monthly Report: 

Displays account information for a selected time period, excluding archived accounts.

* Archive - displays the accounts includined in the archive.

## Rates:
Displays all set rates for homes. By default ,rates are set at 166 rubles for each house. Selecting multiple rates by setting a flag in the checkbox.

* Add - add the rate for the selected house.
* Change price - change price for the selected rates.
* Send to acrive - the rate will be move to archive.
* Delete - permanently deletes the selected rates.

### Archive:

* Show archive rates - shows rates marked as archived.
* Hide - hides displaing of archived rates.

## Discounts:

* Add account - adds a discount to the selected account. When installing the discounts, need to point how many people live in apartment and how many of them are have discount. Discount calculated according by the formula (rate / number of occupants) - percentage of discount.
* Add an apartment - it is not clear whether this function will be needed. It is not currently used in the program.
* Send to the archive - discount will be moved to the archive.
* Delete - permamently deletes the selected discounts.

### Archive:

* Show archive rates - shows discounts marked as archived.
* Hide - hides displaing of archived discounts.

### Percentage and description:

* Add an interest rate - adds a new interest rate for discounters.
* Add a description - adds a new description for discounts.

## Total report: 
Displays the amount received and accrued for a selected tiem period. Percentage - displays the percentage of income and accruals.

* Create total report - creates a report for all houses on the selected street.
* Create report - creates a report on the selected street/house/building.
* Export to excel- save the created report to an excel table.

## Report to on all accounts: 
Create a report on all accounts for the selected time periud.
