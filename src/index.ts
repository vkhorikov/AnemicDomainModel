import startApi from "./api/start";
import startDatabase from "./data/start";
import "./data/tables";

startDatabase().then(() => startApi(3000));
