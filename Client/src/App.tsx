import { useEffect, useState } from 'react'

function App() {
 
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    fetch("https://localhost:5001/api/activities")
      .then(response => response.json())
      .then(data => setActivities(data))

      return () => {}
  }, []);

  return (
    <>
      <h3 className="app" >Reactivities</h3>
      <ul>
        {
          activities.map(activity => (
            <li key={activity.id}>{activity.title}</li>
          ))
        }
      </ul>
    </>
  )
}

export default App
