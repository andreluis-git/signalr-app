import { useState } from "react";

import { Container, Col, Row } from "react-bootstrap";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import WaitingRoom from "./components/WaitingRoom";
import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import ChatRoom from "./components/ChatRoom";
import SendMessageForm from "./components/SendMessageForm";

function App() {
  const [conn, setConnection] = useState();
  const [messages, setMessages] = useState([]);
  const [chatroom, setChatroom] = useState();

  const joinChatRoom = async (username, chatroom) => {
    try {
      const conn = new HubConnectionBuilder()
        .withUrl("http://localhost:5273/Chat")
        .configureLogging(LogLevel.Information)
        .build();

      conn.on("JoinSpecificChatRoom", (username, msg) => {
        setMessages((messages) => [...messages, { username, msg }]);
      });

      conn.on("ReceiveSpecificMessage", (username, msg) => {
        setMessages((messages) => [...messages, { username, msg }]);
      });

      await conn.start();
      await conn.invoke("JoinSpecificChatRoom", { username, chatroom });

      setConnection(conn);
      setChatroom(chatroom);
    } catch (e) {
      console.log(e);
    }
  };

  const sendMessage = async(message) => {
    try {
      await conn.invoke("SendMessage", message)
    }catch(e){
      console.log(e);
    }
  }

  return (
    <>
      <main>
        <Container>
          <Row className="px-5 my-5">
            <Col sm="12">
              <h1 className="font-weight-light">Welcome to the ChatApp</h1>
            </Col>
          </Row>
          {!conn ? (
            <WaitingRoom joinChatRoom={joinChatRoom} />
          ) : (
            <ChatRoom chatroom={chatroom} messages={messages} sendMessage={sendMessage}></ChatRoom>
          )}
        </Container>
      </main>
    </>
  );
}

export default App;
