import { Server } from "colyseus";
import cors from "cors";
import express from "express";
import http from "http";
import { DemoRoom } from "./DemoRoom";
import { FossilDeltaTestRoom } from "./FossilDeltaTestRoom";

const PORT = Number(process.env.PORT || 2567);

const app = express();

/**
 * CORS should be used during development only.
 * Please remove CORS on production, unless you're hosting the server and client on different domains.
 */
app.use(cors());

const gameServer = new Server({
  server: http.createServer(app),
  pingInterval: 0,
});

// Register DemoRoom as "demo"
gameServer.define("demo", DemoRoom);
gameServer.define("fossildelta", FossilDeltaTestRoom);

app.get("/something", function (_req, res) {
  console.log("something!", process.pid);
  res.send("Hey!");
});

// Listen on specified PORT number
gameServer.listen(PORT);

console.log("Running on ws://localhost:" + PORT);
