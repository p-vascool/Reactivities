import React, { useEffect } from 'react';
import { Container } from 'semantic-ui-react';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
import LoadingComponent from './LoadingComponent';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';
import { Route, Routes } from 'react-router-dom';
import HomePage from '../../features/home/HomePage';
import ActivityForm from '../../features/activities/form/ActivityForm';

function App() {
  const { activityStore } = useStore();

  useEffect(() => {
    activityStore.loadActivities();
  }, [activityStore]);

  if (activityStore.loadingInitial) return <LoadingComponent content='Loading app' />

  return (
    <>
      <NavBar />
      <Container style={{ marginTop: '5em' }}>
        <Routes>
          <Route path='/' element={HomePage} />
          <Route path='/activities' element={ActivityDashboard} />
          <Route path='/createActivity' element={ActivityForm} />
        </Routes>
      </Container>

    </>
  );
}

export default observer(App);