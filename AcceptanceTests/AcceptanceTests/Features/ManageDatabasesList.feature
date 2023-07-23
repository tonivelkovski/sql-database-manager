Feature: ManageDatabasesList

As a user
I want to be able to manage databases, their deleting and archiving
so I can manage databases in an organized and more efficient way.

Background:
	Given I am logged as an administrator
	And I am on the Popis baza na serveru form

Scenario: Database properties values modification disabled
	And selected value in the combo box is "2022/2023"
	When I click-double-click on the database with the Name property set to baza_podataka in the DataGridView
	Then the value should not be editable

Scenario: Single database can be selected
	When I click on the row number "1" in the DataGridView
	Then the row "1" in the DataGridView should be marked as selected

Scenario: Multiple databases can be selected
	When I click on the "1" row and on the "2" row in the DataGridView
	Then both row "1" and row "2" should be marked as selected

Scenario: Selected database is deleted
	And selected value in the combo box is "2022/2023"
	When I click on the database record with the Name property set to the "testna_baza_brisanje1" in the DataGridView
	And I click on the button Delete database
	And I select "Yes" in the message box question
	Then database with the Name property set to the "testna_baza_brisanje1" should be deleted

Scenario: Selected database is not deleted
	And selected value in the combo box is "2022/2023"
	When I click on the database record with the Name property set to the "testna_baza_brisanje" in the DataGridView
	And I click on the button Delete database
	And I select "No" in the message box question
	Then database with the Name property set to the "testna_baza_brisanje" should not be deleted

Scenario: Selected databases are deleted
	And selected value in the combo box is "2022/2023"
	When I select the database record with the Name property set to the "testna_baza_brisanje2" and database with the Name property set to the "testna_baza_brisanje3" in the DataGridView
	And I click on the button Delete database
	And I select "Yes" in the message box question
	Then database with the Name property set to the "testna_baza_brisanje2" and database with the Name property set to the "testna_baza_brisanje3" should be deleted

Scenario: Selected databases are not deleted
	And selected value in the combo box is "2022/2023"
	When I select the database record with the Name property set to the "testna_baza_brisanje" and database with the Name property set to the "testna_baza_brisanje2" in the DataGridView
	And I click on the button Delete database
	And I select "No" in the message box question
	Then database with the Name property set to the "testna_baza_brisanje" and database with the Name property set to the "testna_baza_brisanje2" should not be deleted

Scenario: Selected databases are archived
	And selected value in the combo box is "2022/2023"
	When I click on the database record with the Name property set to the "testna_baza" in the DataGridView
	And I click on the button Archive database
	And I select "Yes" in the message box question
	Then database with the Name property set to the "testna_baza" should be archived

Scenario: Selected databases are not archived
	And selected value in the combo box is "2022/2023"
	When I click on the database record with the Name property set to the "testna_baza" in the DataGridView
	And I click on the button Archive database
	And I select "No" in the message box question
	Then database with the Name property set to the "testna_baza" and database with the Name property set to the "testna_baza_2" should not be archived

Scenario: Database cannot be deleted if not selected.
	When I click on the button Delete database
	Then I should see "Please select database record" notification message

Scenario: Database cannot be archived if not selected.
	When I click on the button Archive database
	Then I should see "Please select database record" notification message