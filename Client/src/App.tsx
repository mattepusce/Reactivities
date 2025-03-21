import { List, ListItem, ListItemText, Typography } from "@mui/material";
import { useEffect, useState } from "react";
// npm install axios
import axios from "axios";

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    // chiamata axios per recuperare le attività
    // axios converte automaticamente la risposta in JSON
    axios
      .get<Activity[]>("https://localhost:5001/api/activities")
      .then((response) => setActivities(response.data));

    return () => {};
  }, []);

  return (
    <>
      <Typography variant="h3">Reactivities</Typography>
      <List>
        {activities.map((activity) => (
          <ListItem key={activity.id}>
            <ListItemText>{activity.title}</ListItemText>
          </ListItem>
        ))}
      </List>
    </>
  );
}

export default App;
