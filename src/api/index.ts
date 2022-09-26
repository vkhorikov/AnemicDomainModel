import express, { ErrorRequestHandler } from "express";
import controllers from "./controllers";

const api = express();
api.use(express.json());

api.use("/api", controllers);

const errorMiddleware: ErrorRequestHandler = (err, req, res, next) => {
  console.error(err);
  res.status(500).end();
};
api.use(errorMiddleware);

export default api;
