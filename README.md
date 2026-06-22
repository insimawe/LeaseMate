# LeaseMate
LeaseMate is a simple rental contract management web application designed to help a rent manager quickly create, organize, preview, and generate lease-related documents without manually editing contract files every time a rental deal is closed.

The application allows the user to enter the details of the lessor/owner, lessee/renter, rental unit, lease duration, rental amount, advance payment, security deposit, and rules/regulations. Based on the entered information, LeaseMate can produce a structured Contract of Lease and an Acknowledgement Receipt for printing, signing, and future document generation.

For the first version, LeaseMate focuses on a simple no-login workflow where the user can manage contract records, preview lease documents, and prepare rental paperwork faster and more consistently.

# Main Purpose
LeaseMate is built to replace the manual process of copying and editing multiple contract files. Instead of searching through old documents and changing names, dates, rent amounts, and unit details manually, the user can simply fill out a guided form and generate the needed rental documents.

# Core Features
- Create and manage rental contract records
- Store owner/lessor information
- Store renter/lessee information
- Store property/unit details
- Enter lease start and end dates
- Enter monthly rent, advance payment, and security deposit
- Add or edit rental rules and regulations
- Preview a formatted Contract of Lease
- Preview an Acknowledgement Receipt
- Prepare documents for printing and signing
- Support future upload of valid IDs and signed contracts
- Support future DOCX/PDF document generation

# Technology Stack
Frontend/UI: Blazor Web App
UI Framework: MudBlazor
Styling: Custom CSS
Backend: ASP.NET Core / .NET
Database: SQLite
Data Access: Entity Framework Core Code First
Architecture: Web + Core + Infrastructure
Deployment Target: Render.com
Storage: Local/Persistent disk storage

# Project Architecture
LeaseMate.Web
LeaseMate.Core
LeaseMate.Infrastructure
