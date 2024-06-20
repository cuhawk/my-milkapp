import React from 'react';
import { Route, Routes, Navigate } from 'react-router-dom';
import './App.css';
import Dashboard from '../Dashboard/Dashboard';
import Login from '../Login/Login';
import Preferences from '../Preferences/Preferences';
import useToken from './useToken';

function App() {
  const { token, setToken } = useToken();
  
  return (
    <div className="wrapper">
        <Routes>
          <Route path="/login" element={<Login setToken={setToken} />} />
          
          <Route path="/dashboard" element={token ? <Dashboard /> : <Navigate to="/login" />} />

          <Route path="/preferences" element={token ? <Preferences /> : <Navigate to="/login" />} />

          <Route path="*" element={<Navigate to="/login" />} />
        </Routes>
    </div>
  );
}

export default App;
