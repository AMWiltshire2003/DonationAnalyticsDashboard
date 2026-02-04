# Donation Analytics Dashboard

## 📌 Overview

The **Donation Analytics Dashboard** is a WPF desktop application built with **C# and XAML**. It is designed to help organisations monitor, filter, and analyse donation data in a clear and operationally focused way.

The application prioritises **data accuracy, usability, and clean structure** over visual complexity. It demonstrates practical decision-making by focusing on features that would realistically be used by staff managing donations.

This project was developed as a **portfolio project** to demonstrate junior-level software development skills suitable for **internships and entry-level roles**.

---

## 🎯 Project Goals

* Display donation data in a clear, structured format
* Provide key performance indicators (KPIs) for quick insight
* Allow filtering of donations by date range
* Maintain clean separation between UI and logic
* Produce a stable, maintainable application suitable for real-world use

---

## 🧩 Features

### ✅ Date Range Filtering

Users can filter donation records using **From** and **To** date pickers. This allows focused analysis of donations over specific periods.

### ✅ KPI Summary Cards

The dashboard includes KPI cards that display:

* **Pending Donations**
* **Distributed Donations**

These values update based on the selected date range, providing an immediate operational snapshot.

### ✅ Donation Data Table

A DataGrid displays raw donation records, allowing users to:

* View donation details
* Verify individual records
* Cross-check totals against KPIs

### ✅ Category Summary Table

A second DataGrid aggregates donations by category, helping identify where resources are most needed.

---

## 🖥️ User Interface Design

* Built using **WPF XAML**
* Clean, structured layout using `Grid`, `StackPanel`, and `Border`
* Section headers added for clarity and professionalism
* KPI cards visually differentiated to highlight key data

The UI is intentionally simple and functional, reflecting real-world internal tools rather than consumer-facing applications.

---

## 🛠️ Technologies Used

* **C# (.NET)**
* **WPF (XAML)**
* **DataGrid controls** for structured data display
* **MVVM-friendly structure** (logic separated from UI where appropriate)

---

## 📊 Why No Charts?

Charts and advanced visual analytics were considered during planning. However, for this iteration, the focus was placed on:

* Stability
* Correct data processing
* Clear tabular presentation

In many operational environments, tables and KPIs are preferred for accuracy and auditing. Visual analytics are marked as a **future enhancement**.

---

## 🚀 Future Improvements

* Add visual charts (e.g., category distribution, trends over time)
* Export filtered data to CSV
* Improve theming and accessibility
* Integrate a database backend for persistent storage

---

## 📁 How to Run the Project

1. Clone the repository
2. Open the solution in **Visual Studio**
3. Restore NuGet packages if prompted
4. Run the application using the **WPF startup project**

---

## 👤 Author

**Adrian Wiltshire**
Aspiring Software Developer | Junior / Internship Candidate

---

## 📄 License

This project is provided for educational and portfolio purposes.
