# Task 1. Order check engine

Conditions:

There is a REST API for customers order requests uploading. Along with other request information orders can contain three types of documents (ID card, place of registration, extract from the register of enterprises) in different combinations, which should be validated. 

## Request types:

- Card issue for private individual
    - ID card
- Card issue for corporate individual 
    - ID card
    - extract from the register of enterprises
- Registration of new corporate customer
    - extract from the register of enterprises
- Inquiry on private individual
    - ID card
    - place of registration
- Registration of new private customer
    - ID card
    - place of registration
- Inquiry on corporate customer
    - extract from the register of enterprises
    - place of registration

Each request contain API customer identifier.

## Limitations:

1. Each document validation is triggered based on customer trustworthiness, which is available as a customer attribute and must be stored in file

2. Document data validation is performed by an external validation engine by document id. For the purpose of this task, external system can be represented by the service class.

3. Validation engine returns one of the values: VALID or NOT_VALID

## Requirements:

1. Create UML class diagram

2. Create solution for all types for three customers

3. Write tests for the developed solutions (usage of testing frameworks is not required)

# Task 2. Exception processing optimisation

Implement own class for unchecked exception processing, which will make such exception processing faster.

# Task 3. Refactoring

Refactor the class RPCService. Use dependency inversion principle.

```
public class RPCService {
    private final Logger log = LoggerFactory.getLogger(this.getClass().getSimpleName());
    private RestTemplate restTemplate;

    public RPCService() {
        restTemplate = new RestTemplate();
    }

    public RpcResponse registerNewClient(Client client) {
        log.debug("Register new client RPC service called with parameters - " + client);
        RpcRequest request = new RpcRequest()
                .withJsonRpc("2.0")
                .withMethod("REGISTER_NEW_CLIENT")
                .withId("1")
                .withParameters(client);
        log.debug("Register new client RPC request prepared with parameters - " + request);
        RpcResponse response = null;
        try {
            response = restTemplate.url("https://server.host.lv/client").method("POST").body(request).execute();
        } catch (Exception e) {
            log.info("RPC call failed");
        }
        log.debug("Register new client RPC response received - " + response);
        return response;
    }

    public RpcResponse registerNewBusinessClient(BusinessClient client) {
        log.debug("Register new client RPC service called with parameters - " + client);
        RpcRequest request = new RpcRequest()
                .withJsonRpc("2.0")
                .withMethod("REGISTER_NEW__BUSINESS_CLIENT")
                .withId("1")
                .withParameters(client);
        log.debug("Register new client RPC request prepared with parameters - " + request);
        RpcResponse response = null;
        try {
            response = restTemplate.url("https://server.host.lv/client").method("POST").body(request).execute();
        } catch (Exception e) {
            log.info("RPC call failed");
        }
        log.debug("Register new client RPC response received - " + response);
        if(response.getErrorCode() != 0) throw new RPCServiceException("Unknown exception");
        return response;
    }

    public RpcResponse getPrivateClientsList(String clientId) {
        log.debug("Register new client RPC service called with parameters - " + clientId);
        RpcRequest request = new RpcRequest()
                .withJsonRpc("2.0")
                .withMethod("GET_REGISTERED_CLIENTS")
                .withId("1")
                .withParameters(clientId);
        log.debug("Register new client RPC request prepared with parameters - " + request);
        RpcResponse response = null;
        try {
            response = restTemplate.url("https://server.host.lv/client").body(request).method("GET").execute();
        } catch (Exception e) {
            log.info("RPC call failed");
        }
        log.debug("Register new client RPC response received - " + response);
        if(response.getErrorCode() != 0) throw new RPCServiceException("Unknown exception");
        return response;
    }

    public RpcResponse editClients(Client client) {
        log.debug("Register new client RPC service called with parameters - " + client);
        RpcRequest request = new RpcRequest()
                .withJsonRpc("2.0")
                .withMethod("EDIT_CLIENT")
                .withId("1")
                .withParameters(client);
        log.debug("Register new client RPC request prepared with parameters - " + request);
        RpcResponse response = null;
        try {
            response = restTemplate.url("https://server.host.lv/client").method("PATCH").body(request).execute();
        } catch (Exception e) {
            log.info("RPC call failed");
        }
        log.debug("Register new client RPC response received - " + response);
        if(response.getErrorCode() != 0) throw new RPCServiceException("Unknown exception");
        return response;
    }
}
```