# iForceAssignment
Deployment Strategy
If this were a production system, which two GCP services would you use:

- One to deploy the C# API\
 Would use Cloud Run - autoscaling, deploy as container, fully managed, IAM server auth, multiple revisions and easy rollback.
- One to deploy the Next.js app\
 Would also use Cloud Run for similar reasons, but for frontend there's support for server side rendering, same deployment model as the API, easy CI/CD, scales independently.

Explain briefly why you chose them.
- JWT Validation\
If the C# API were deployed to Cloud Run and used real JWTs, how would the API
validate token signatures without calling the identity provider on every request?
You may answer in a few concise bullet points.

- In case an external auth provider like Auth0 or Google is used, the JWTs are signed with asymmetric key and public key can be used to validate.
- This is usually built-in in the SDK and and automatically cached in memory.
- Since Cloud Run is stateless this would be done on container startup/first request. Usually this is not a problem and acceptable.
 