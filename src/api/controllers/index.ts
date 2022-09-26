import { Router } from "express";
import Customer from "../../data/tables/Customer";

const controllers = Router();

controllers.get("/:id", async (req, res) => {
  const customer = await Customer.findByPk(req.params.id);

  if (customer === null) {
    res.sendStatus(404);
  } else {
    res.status(200).json(customer);
  }
});

controllers.get("/", async (req, res) => {
  const customers = await Customer.findAll();

  res.status(200).json(customers);
});

controllers.post("/", async (req, res) => {
  try {
    await Customer.create({ ...req.body, status: "regular" });
    res.sendStatus(200);
  } catch (error) {
    res.sendStatus(500);
  }
});

export default controllers;
