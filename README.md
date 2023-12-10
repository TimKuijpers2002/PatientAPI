<div align="center">
  <h3 align="center">PatientAPI Documentation</h3>
    
  <a>
    <img src="https://github.com/TimKuijpers2002/Medix-Hub/blob/master/Medix-logo.jpg" alt="Logo" width="250" height="250">
  </a>
</div>

# Developer(s) SEP 2023 - JAN 2024
</div>

---

<table align=center>
  <tbody>
    <tr>
     <td align="center"><a><img src="https://github.com/TimKuijpers2002.png" width="100px;" alt="Tim Kuijpers"/><br /><sub><b>Tim Kuijpers</b></a></td>
  </tbody>
</table>

# :man_technologist: Short Introduction
The PatientAPI is a service within the Medix-hub system that is operated to create, mutate, retrieve and delete the personal data of a patient.

These patients get enlisted into the system when visiting a hospital or general practitioners office but only if the patient agrees on data being stored.

<br/>


### Languages and Tools used
These following technologies are used the most frequent amount within this project:
<div align=center>
  <img src="https://avatars.githubusercontent.com/u/7802525?s=48&v=4" title="GRPC" alt="GRPC" width="60" height="60"/>&nbsp;
  <img src="https://raw.githubusercontent.com/devicons/devicon/1119b9f84c0290e0f0b38982099a2bd027a48bf1/icons/csharp/csharp-original.svg" title="Csharp" alt="Csharp" width="60" height="60"/>&nbsp;
  <img src="https://raw.githubusercontent.com/devicons/devicon/1119b9f84c0290e0f0b38982099a2bd027a48bf1/icons/dotnetcore/dotnetcore-original.svg" title="dotnet" alt="dotnet" width="60" height="60"/>&nbsp;
  <img src="https://raw.githubusercontent.com/devicons/devicon/1119b9f84c0290e0f0b38982099a2bd027a48bf1/icons/microsoftsqlserver/microsoftsqlserver-plain-wordmark.svg" title="MSSQL"  alt="MSSQL" width="60" height="60"/>&nbsp;
  <img src="https://raw.githubusercontent.com/devicons/devicon/1119b9f84c0290e0f0b38982099a2bd027a48bf1/icons/docker/docker-original.svg" title="Docker" alt="Docker" width="60" height="60"/>&nbsp;
  <img src="https://raw.githubusercontent.com/kubernetes/kubernetes/9884746f0fd338c393d23dbb2a87d118a34fe5e5/logo/logo.svg" title="Kubernetes" alt="Kubernetes" width="60" height="60"/>&nbsp;
  <img src="https://raw.githubusercontent.com/devicons/devicon/1119b9f84c0290e0f0b38982099a2bd027a48bf1/icons/github/github-original.svg" title="Git" **alt="Git" width="60" height="60"/>
</div>
<br/>

The following technologies also contribute to this project:
- Entity Framework
- Snyk
- SonarCloud
- Azure
- K6 by Grafana
- Grafana
- Influx DB
- Proto
- JSON Transcoding
- Postman
- GHZ performance tests


## API Endpoints (from gateway)
The application has the following endpoints:

HTTP method | API endpoints             | Description
------------|---------------------------|---------------------------
 GET        | /api/v1/patient           | Get all patients
 GET        | /api/v1/patient/{id}      | Get patient by ID
 POST       | /api/v1/patient           | Create patient
 POST       | /api/v1/deceased          | Declare patient as deceased
 PUT        | /api/v1/patient           | Update patient
 DELETE     | /api/v1/patient/{id}      | Delete patient

(Upcoming with enterprise KrakenD)

GRCP method | API endpoints             | Description
------------|---------------------------|---------------------------
 GET        | /grpc/v1/patient           | Get all patients
 GET        | /grpc/v1/patient/{id}      | Get patient by ID
 POST       | /grpc/v1/patient           | Create patient
 POST       | /grpc/v1/deceased          | Declare patient as deceased
 PUT        | /grpc/v1/patient           | Update patient
 DELETE     | /grpc/v1/patient/{id}      | Delete patient

## Cloning & local instance

To get this service running on your local device look at the [Medix-Hub repository](https://github.com/TimKuijpers2002/Medix-Hub).

## Contributing
Pull requests are not desired. This was a project for school within my study at Fontys HBO-ICT Software engineering.
