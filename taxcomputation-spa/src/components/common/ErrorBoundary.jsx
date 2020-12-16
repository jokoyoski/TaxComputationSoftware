import React, { Component } from "react";

const logErrorToConsole = (error, errorInfo) => {
  console.log(error, errorInfo);
};

/**
 * Error Boundary Component - catches error in children component and diplay a message to the user
 * E.g.:
 * ```html
 * <ErrorBoundary>
 *   <App />
 * </ErrorBoundary>
 * ```
 */
class ErrorBoundary extends Component {
  constructor(props) {
    super(props);
    this.state = { hasError: false, offline: false };
  }

  componentDidMount() {
    window.addEventListener("online", () => this.setState({ ...this.state, offline: false }));
    window.addEventListener("offline", () => this.setState({ ...this.state, offline: true }));
  }

  static getDerivedStateFromError(_error) {
    // Update state so the next render will show the fallback UI.
    return { hasError: true };
  }

  componentDidCatch(error, errorInfo) {
    logErrorToConsole(error, errorInfo);
  }

  render() {
    if (this.state.hasError) {
      return (
        <div className="error-boundary">
          <h2 style={{ marginBottom: 0 }}>An Error Occurred</h2>
          <p style={{ margin: 0 }}>
            contact your admin for <em>error logs</em>
          </p>
        </div>
      );
    }

    return (
      <div className="app">
        <div className="app-container">{this.props.children}</div>
        {this.state.offline && (
          <div
            style={{
              position: "fixed",
              zIndex: 1000,
              left: 0,
              right: 0,
              top: 0,
              bottom: 0,
              background: "rgba(255, 255, 255, 0.95)"
            }}>
            <div
              style={{
                display: "flex",
                flexDirection: "column",
                justifyContent: "center",
                alignItems: "center",
                width: "100vw",
                height: "100vh"
              }}>
              <p style={{ fontSize: 20, paddingTop: 20, textAlign: "center" }}>
                No internet!
                <br />
                Reconnect to keep working
              </p>
            </div>
          </div>
        )}
      </div>
    );
  }
}

export default ErrorBoundary;
