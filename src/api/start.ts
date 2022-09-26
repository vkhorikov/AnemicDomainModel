import api from ".";

const startApi = async (port: number) => {
  console.log("Launching express server...");
  api.listen(port, () => {
    console.info(`App listening on port ${port}!`);
  });
};

export default startApi;
