import React from 'react';
import EventsTable from '../components/EventsTable';
import '../styles/AdminPanel.css';

const AdminPanel = () => {
    return (
        <div className="admin-panel">
            <h1>Admin Panel</h1>
            <EventsTable />
        </div>
    );
};

export default AdminPanel;
