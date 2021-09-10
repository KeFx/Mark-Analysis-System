# Mark-Analysis-System
A system that records student marks, displays them and provides a search feature. <br/>
Written by KeFx for school work.

## Program features and evidence documentation
*(This file contains all program usage and features.)* <br/>
### Main Menu
This program is a Visual Basic console application that indefinitely loops a menu prompt when run and *only* exits <br/>
when user enters the option "-1". Except for that, there are three available action options:<br/>
1. Enter new data for a student,
2. Display all data with average, min and max,
3. Search for a student's data by ID number. <br/>

<img src="https://user-images.githubusercontent.com/62463532/132792056-1e1df741-e02d-489f-8f81-6a994029c570.png" width="500" height="320"><br/>

**Any other inputs here would lead to an error:<br/>**
<img src="https://user-images.githubusercontent.com/62463532/132790366-3ccd6a9b-a1bf-4691-a2c1-82a140b715ac.png" width="450" height="130">

### Selection 1
Entering "1" from main menu prompt would lead you to the enter data prompt:
<img src="https://user-images.githubusercontent.com/62463532/132791048-6a9c1fc4-1040-4519-80a2-52dfa119ba6b.png" width="450" height="120"><br/>
Where the program asks you to enter full data starting with student's ID number. (If you are trying to edit a pre-entered student's data<br/>
simply enter full data again and the old data will be overwrite). Entering a valid data will have it stored in the program's database and<br/>
the following is displayed:<br/>
<img src="https://user-images.githubusercontent.com/62463532/132791601-8e1485bb-3d17-45a8-bdf6-d2da5610a0f4.png" width="450" height="130"><br/>
*Note: Any results under 20 will be automatically converted to 20 before it is stored stored. (for evidence see Selection 2)*<br/>

**Validation evidence:**<br/>

* Invalid Input data type:<br/>
<img src="https://user-images.githubusercontent.com/62463532/132793196-dbe4b655-cdc3-4f9d-ac4f-f00b0bc4a235.png" width="450" height="130"><br/>

* Invalid Input format:<br/>
<img src="https://user-images.githubusercontent.com/62463532/132792574-f10ff23b-3451-4291-8a62-60064c6baec2.png" width="450" height="130"><br/>

* Invalid ID number:<br/>
<img src="https://user-images.githubusercontent.com/62463532/132792823-17b2b862-ca95-46bc-8b05-d6eccaf22cc8.png" width="450" height="130"><br/>

* Invalid result data:<br/>
<img src="https://user-images.githubusercontent.com/62463532/132793019-70945e0e-f8ce-495c-b5b3-9608aa946c97.png" width="450" height="130"><br/>


### Selection 2
Entering "2" from main menu prompt would display all 

