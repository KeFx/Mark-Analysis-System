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

### Selection 1 - Input
Entering "1" from main menu prompt would lead you to the enter data prompt:
<img src="https://user-images.githubusercontent.com/62463532/132791048-6a9c1fc4-1040-4519-80a2-52dfa119ba6b.png" width="450" height="120"><br/>
Where the program asks you to enter full data starting with student's ID number. (If you are trying to edit a pre-entered student's data<br/>
simply enter full data again and the old data will be overwrite). Entering a valid data will have it stored in the program's database and<br/>
the following is displayed:<br/>
<img src="https://user-images.githubusercontent.com/62463532/132791601-8e1485bb-3d17-45a8-bdf6-d2da5610a0f4.png" width="450" height="130"><br/>
*Note: Any results under 20 will be automatically converted to 20 before it is stored stored. (for evidence see Selection 2 )*<br/>

**Validation evidence:**<br/>

* Invalid Input data type:<br/>
<img src="https://user-images.githubusercontent.com/62463532/132793196-dbe4b655-cdc3-4f9d-ac4f-f00b0bc4a235.png" width="450" height="130"><br/>

* Invalid Input format:<br/>
<img src="https://user-images.githubusercontent.com/62463532/132792574-f10ff23b-3451-4291-8a62-60064c6baec2.png" width="450" height="130"><br/>

* Invalid ID number:<br/>
<img src="https://user-images.githubusercontent.com/62463532/132792823-17b2b862-ca95-46bc-8b05-d6eccaf22cc8.png" width="450" height="130"><br/>

* Invalid result data:<br/>
<img src="https://user-images.githubusercontent.com/62463532/132793019-70945e0e-f8ce-495c-b5b3-9608aa946c97.png" width="450" height="130"><br/>


### Selection 2 - Display
Entering "2" from main menu prompt would display all stored data along with its summay(Average, Max and Min<br/>
Test Data:<br/>
  20100,50,63,77<br/>
  20101,55,69,82<br/>
  20102,62,74,94<br/>
  20103,20,30,40<br/>
  20104,74,36,80<br/>
  20105,30,54,90<br/>
  20106,93,33,88<br/>
  20107,88,99,99<br/>
  20108,78,82,100<br/>
  20109,40,60,40<br/>
* Display output:<br/>
<img src="https://user-images.githubusercontent.com/62463532/132981817-d9926ea2-db33-4f02-b5e8-68af26e34311.png" width="410" height="240"><br/>
* If some results entered were under 20 it is converted to 20 befored stored and displayed:<br/>
  e.g. 20300,19,1,21<br/>
  Display result:<br/>
  <img src="https://user-images.githubusercontent.com/62463532/132929024-2abe56a2-bdb9-4df4-ad0f-e300b4fffa27.png" width="300" height="150"><br/>
  
  
### Selection 3 - Search
Entering "3" leads to search for data prompt:<br/>
<img src="https://user-images.githubusercontent.com/62463532/132929147-5df0945b-6d73-49ba-935e-298febb72b42.png" width="380" height="115"><br/>

User is to enter a student's ID number ins format of "#####" without quotes.
example data 20300,19,1,21<br/>
* Result:<br/>
  <img src="https://user-images.githubusercontent.com/62463532/132929300-820aa9f9-6b2a-4120-ba5c-7345f5d443a5.png" width="380" height="115"><br/>
* Entering a invalid value or non-existing ID number will lead to error and program loops back to menu prompt:<br/>
  <img src="https://user-images.githubusercontent.com/62463532/132929428-d9cfce9a-f291-4c61-81e1-3d2d43622393.png" width="380" height="115"><br/>
  
 
*Any invalid input at any stage will **not** crash program but simply looping back to menu prompt<br/>
*To exit out of program, enter "-1" without quotation marks while at menu selection

