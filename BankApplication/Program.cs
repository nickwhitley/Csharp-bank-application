﻿// See https://aka.ms/new-console-template for more information
using BankApplication.ConsoleView;
using BankApplication.Factories;
using BankApplication.Utilities;
using BankApplication.Views;

ViewManager viewManager = new ViewManager();

#region test_environment

Factory factory = new Factory();
DataManager dataManager = new DataManager();
var testUser = factory.CreateUser("testFirstName", "testLastName", "test@email.com", 111111111, "testUsername", "testPassword");
var testAccount = factory.CreateBankAccount(500m, BankApplication.Enums.BankAccountType.Checking);
dataManager.SaveUser(testUser);
dataManager.SaveUserAccount(testUser, testAccount);

viewManager.ChangeToAccountView(testUser);

#endregion

viewManager.ChangeView(ViewManager.View.InitialView);