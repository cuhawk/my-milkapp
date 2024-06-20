import React, { useState, useEffect } from "react";
import axios from "axios";
import PropTypes from "prop-types";
import "./Login.css";
import { useNavigate } from "react-router-dom";

async function loginUser(credentials) {
  try {
    const response = await axios.post(
      "https://localhost:7009/api/Auth/Login",
      credentials,
      {
        headers: {
          "Content-Type": "application/json",
        },
      }
    );
    return response.data;
  } catch (error) {
    console.error("Error logging in:", error);
    throw error;
  }
}

async function registerUser(details) {
  try {
    const response = await axios.post(
      "https://localhost:7009/api/Auth/Register",
      details,
      {
        headers: {
          "Content-Type": "application/json",
        },
      }
    );
    return response.data;
  } catch (error) {
    console.error("Error registering:", error);
    throw error;
  }
}

export default function Login({ setToken }) {
  const [username, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [signUpName, setSignUpName] = useState("");
  const [signUpEmail, setSignUpEmail] = useState("");
  const [signUpPassword, setSignUpPassword] = useState("");
  const [error, setError] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    const signUpButton = document.getElementById('signUp');
    const signInButton = document.getElementById('signIn');
    const container = document.getElementById('container');

    signUpButton.addEventListener('click', () => {
      container.classList.add("right-panel-active");
    });

    signInButton.addEventListener('click', () => {
      container.classList.remove("right-panel-active");
    });

    return () => {
      signUpButton.removeEventListener('click', () => {
        container.classList.add("right-panel-active");
      });
      signInButton.removeEventListener('click', () => {
        container.classList.remove("right-panel-active");
      });
    };
  }, []);

  const handleLoginSubmit = async (e) => {
    e.preventDefault();
    try {
      const tokenData = await loginUser({
        Email: username,
        Password: password,
      });

      setToken(tokenData.token);
      navigate("/dashboard");
    } catch (error) {
      setError("Invalid username or password. Please try again.");
      console.error("Login error:", error);
    }
  };

  const handleSignUpSubmit = async (e) => {
    e.preventDefault();
    try {
      await registerUser({
        fullName: signUpName,
        Email: signUpEmail,
        Password: signUpPassword,
      });
      setError("");
      alert("Registration successful! Please sign in.");
      document.getElementById('signIn').click();
    } catch (error) {
      setError("Error registering account. Please try again.");
      console.error("Registration error:", error);
    }
  };

  return (
    <div className="login-wrapper">
      <h2>Sign in/up Form</h2>
      <div className="container" id="container">
        <div className="form-container sign-up-container">
          <form onSubmit={handleSignUpSubmit}>
            <h1>Create Account</h1>
            <span>or use your email for registration</span>
            <input
              type="text"
              placeholder="Name"
              value={signUpName}
              onChange={(e) => setSignUpName(e.target.value)}
              required
            />
            <input
              type="email"
              placeholder="Email"
              value={signUpEmail}
              onChange={(e) => setSignUpEmail(e.target.value)}
              required
            />
            <input
              type="password"
              placeholder="Password"
              value={signUpPassword}
              onChange={(e) => setSignUpPassword(e.target.value)}
              required
            />
            <div className={`error-message ${error ? "show" : ""}`}>
              {error}
            </div>
            <button type="submit">Sign Up</button>
          </form>
        </div>
        <div className="form-container sign-in-container">
          <form onSubmit={handleLoginSubmit}>
            <h1>Sign in</h1>
            <span>or use your account</span>
            <input
              type="email"
              placeholder="Email"
              value={username}
              onChange={(e) => setUserName(e.target.value)}
              required
            />
            <input
              type="password"
              placeholder="Password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
            <div className={`error-message ${error ? "show" : ""}`}>
              {error}
            </div>
            <a href="#">Forgot your password?</a>
            <button type="submit">Sign In</button>
          </form>
        </div>
        <div className="overlay-container">
          <div className="overlay">
            <div className="overlay-panel overlay-left">
              <h1>Welcome Back!</h1>
              <p>To keep connected with us please login with your personal info</p>
              <button className="ghost" id="signIn">Sign In</button>
            </div>
            <div className="overlay-panel overlay-right">
              <h1>Hello, Friend!</h1>
              <p>Enter your personal details and start journey with us</p>
              <button className="ghost" id="signUp">Sign Up</button>
            </div>
          </div>
        </div>
      </div>
      <footer>
        <p>
          Created with <i className="fa fa-heart" /> by
          <a target="_blank" href="https://florin-pop.com">Hung</a>
          - Read how I created this and how you can join the challenge
          <a target="_blank" href="https://www.florin-pop.com/blog/2019/03/double-slider-sign-in-up-form/">here</a>.
        </p>
      </footer>
    </div>
  );
}

Login.propTypes = {
  setToken: PropTypes.func.isRequired,
};
