## APBD Tutorial 8

---

The API connects to an [2022 MSSQL Server](https://hub.docker.com/r/microsoft/mssql-server)

---

Command for starting docker container:
```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YhP4sswd" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```