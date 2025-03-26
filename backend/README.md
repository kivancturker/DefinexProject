### SETUP AND RUN STEPS

## Keycloak Setup
I used keycloak as identity provider. Here are steps to initialize the keycloak container ready to use.
Visit localhost:8181
Create a realm called definex
Goto Realm Settings on the left sidebar
Inside realm settings choose "Login" and enable "User registration"

Pick Client on the left sidebar again.
Click Create Client
Choose OpenId Connect, Client ID: public-client next check Implicit flow, direct access and standard flow if not checked next
Valid redirect URIs: http://localhost:8080/* and Web Origin: http://localhost:8080 then save
