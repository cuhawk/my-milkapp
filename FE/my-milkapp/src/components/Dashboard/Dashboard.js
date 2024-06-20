import React from 'react';
import PropTypes from 'prop-types';

function Dashboard({ setToken }) {
  const handleLogout = () => {
    localStorage.removeItem('token');
    window.location.href = '/login';
  };

  return (
    <div>
      <h1>Welcome to Dashboard</h1>
      <button onClick={handleLogout}>Logout</button>
    </div>
  );
}

Dashboard.propTypes = {
  setToken: PropTypes.func.isRequired
};

export default Dashboard;
